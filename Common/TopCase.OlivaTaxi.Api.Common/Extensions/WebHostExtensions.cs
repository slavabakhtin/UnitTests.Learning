using System;
using Google.Api.Gax;
using Google.Cloud.Diagnostics.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TopCase.OlivaTaxi.Api.Common.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHostBuilder ConfigureOlivaTaxiLogging(this IWebHostBuilder webHostBuilder)
        {
            Console.WriteLine($"Application is running on platform: {Platform.Instance().Type}");

            if (Platform.Instance().Type == PlatformType.Unknown)
            {
                webHostBuilder.ConfigureLogging((hostingContext, loggingBuilder) =>
                {
                    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                    loggingBuilder.AddEventSourceLogger();
                });
            }
            else
            {
                webHostBuilder.ConfigureLogging((hostingContext, loggingBuilder) =>
                {
                    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                });
                webHostBuilder.UseGoogleDiagnostics();
            }

            return webHostBuilder;
        }

        public static IWebHost MigrateDb<TContext>(this IWebHost webHost) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<DbMigrator<TContext>>().Migrate().Wait();
                var dataSeeder = scope.ServiceProvider.GetService<DictionaryDataSeeder<TContext>>();
                dataSeeder?.Seed().Wait();
            }

            return webHost;
        }
    }
}