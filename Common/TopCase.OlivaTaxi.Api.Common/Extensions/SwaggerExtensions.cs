using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace TopCase.OlivaTaxi.Api.Common.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = GetApiName(), Version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[]{}
                    }
                });

                var xmlDocName = Path.Combine(AppContext.BaseDirectory, $"{GetEntryAssemblyName()}.xml");
                options.IncludeXmlComments(xmlDocName);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            var assemblyName = GetCleanEntryAssemblyName();

            app.UseSwagger(c =>
            {
                c.RouteTemplate = $"{assemblyName}/swagger/{{documentName}}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{assemblyName}/swagger/v1/swagger.json", "Oliva Taxi API");
                c.RoutePrefix = $"{assemblyName}/swagger";

                c.DocExpansion(DocExpansion.List);
            });

            return app;
        }

        private static string GetCleanEntryAssemblyName()
        {
            return GetEntryAssemblyName()
                .Remove(0, "TopCase.OlivaTaxi.".Length)
                .Replace(".Api", "")
                .Replace(".", "")
                .ToLower();
        }

        private static string GetApiName()
        {
            return GetEntryAssemblyName()
                .Remove(0, "TopCase.OlivaTaxi.".Length)
                .Replace(".Api", "");
        }

        private static string GetEntryAssemblyName()
        {
            return Assembly.GetEntryAssembly()?.GetName().Name;
        }
    }
}