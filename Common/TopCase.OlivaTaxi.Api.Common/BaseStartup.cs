using Google.Cloud.Diagnostics.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TopCase.OlivaTaxi.Api.Common.Extensions;
using TopCase.OlivaTaxi.Api.Common.Middlewares;

namespace TopCase.OlivaTaxi.Api.Common
{
    public abstract class BaseStartup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostEnvironment { get; }

        public BaseStartup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }
        
        public virtual void ConfigureServices(IServiceCollection services)
        {
            var gcpProjectId = GooglePlatformHelper.GetProjectId(Configuration);

            services.AddCommonApiServices(Configuration, HostEnvironment);

            services.AddFirebaseAuthentication(gcpProjectId);
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsLocal())
            {
                app.UseGoogleTrace();
                app.UseGoogleExceptionLogging();
            }

            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpExceptionMiddleware();
            app.UseRouting();
            app.UseCors();
            app.UseSwaggerDocumentation();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/");
                endpoints.MapControllers();
            });
        }
    }
}