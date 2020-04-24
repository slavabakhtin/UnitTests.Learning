using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Topshelf;

namespace Example.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<Service>();
                x.EnableServiceRecovery(r => r.RestartService(TimeSpan.FromSeconds(10).Seconds));
                x.SetServiceName("TestService");
                x.StartAutomatically();
                CreateHostBuilder(args).Build();
            });
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
