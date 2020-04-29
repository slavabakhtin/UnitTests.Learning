using System;
using System.Text.Json.Serialization;
using AutoMapper;
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
            IConfiguration configuration)
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

            services.AddHttpContextAccessor();
            services.AddEiipLogging(configuration);

            return services;
        }

        public static IServiceCollection AddEiipLogging(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
            });

            return services;
        }

        public static IServiceCollection AddEiipContext<TContext>(this IServiceCollection services, IConfiguration configuration)
            where TContext : DbContext
        {
            services.AddScoped(typeof(DbMigrator<TContext>));
            services.AddDbContext<TContext>(opts => opts.UseSqlServer(configuration.GetConnectionString(typeof(TContext).Name)));

            return services;
        }
    }
}
