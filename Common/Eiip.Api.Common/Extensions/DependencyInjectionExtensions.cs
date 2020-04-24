using System;
using System.Text.Json.Serialization;
using AutoMapper;
using Eiip.Api.Common.Middlewares;
using Google.Cloud.Diagnostics.AspNetCore;
using Google.Cloud.Diagnostics.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Eiip.Api.Common.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCommonApiServices(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwaggerDocumentation();

            services.AddAutoMapper(x => {}, AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddHealthChecks();
            services.AddSingleton<OlivaTaxiProblemDetailsFactory>();

            services.AddHttpContextAccessor();
            services.AddLogging(configuration, hostEnvironment.IsLocal());

            return services;
        }

        public static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration, bool isLocal)
        {
            var gcpProjectId = GooglePlatformHelper.GetProjectId(configuration);
            if (isLocal)
            {
                services.AddHttpClient("internalApiClient");

                services.AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                    loggingBuilder.AddEventSourceLogger();
                });

                return services;
            }

            services.AddGoogleExceptionLogging(options =>
            {
                options.ProjectId = gcpProjectId;
                options.ServiceName = GooglePlatformHelper.GetServiceName(configuration);
                options.Version = GooglePlatformHelper.GetVersion(configuration);
            });

            services.AddGoogleTrace(options => { options.ProjectId = gcpProjectId; });
            services.AddHttpClient("internalApiClient")
                .AddOutgoingGoogleTraceHandler();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
            });
            services.AddSingleton<ILoggerProvider>(sp => GoogleLoggerProvider.Create(sp, gcpProjectId));

            return services;
        }

        public static IServiceCollection AddContext<TContext>(this IServiceCollection services, IConfiguration configuration)
            where TContext : DbContext
        {
            services.AddScoped(typeof(DbMigrator<TContext>));
            services.AddDbContext<TContext>(opts => opts.UseSqlServer(configuration.GetConnectionString(typeof(TContext).Name)));

            return services;
        }
    }
}
