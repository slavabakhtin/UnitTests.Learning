using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Google.Cloud.Diagnostics.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TopCase.OlivaTaxi.Api.Common.Extensions;

namespace TopCase.OlivaTaxi.Api.Common
{
    public abstract class BaseStreamingStartup
    {
        protected IConfiguration Configuration { get; }
        protected IWebHostEnvironment HostEnvironment { get; }

        protected BaseStreamingStartup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddCommonApiServices(Configuration, HostEnvironment);

            var gcpProjectId = GooglePlatformHelper.GetProjectId(Configuration);
            services.AddFirebaseAuthentication(gcpProjectId, options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments(HubPath))
                        {
                            context.Token = accessToken;
                        }

                        return Task.CompletedTask;
                    }
                };
            });
            
            services
                .AddSignalR()
                .AddStackExchangeRedis(Configuration.GetValue<string>("RedisSettings:ConnectionString"), options =>
                {
                    options.Configuration.ChannelPrefix = $"{HostEnvironment.EnvironmentName}_{Configuration.GetValue<string>("RedisSettings:ChannelPrefix")}";
                })
                .AddJsonProtocol(opts => opts.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            if (!HostEnvironment.IsLocal())
            {
                app.UseGoogleTrace();
                app.UseGoogleExceptionLogging();
            }

            if (HostEnvironment.IsLocal())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSwaggerDocumentation();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/");
                MapHub(endpoints);
                endpoints.MapControllers();
            });
        }

        protected abstract string HubPath { get; }

        protected abstract void MapHub(IEndpointRouteBuilder endpointRouteBuilder);
    }
}