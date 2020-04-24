using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TopCase.OlivaTaxi.Api.Common;
using Topshelf;

namespace Eiip.PushNotifications.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x => {
                x.Service<Worker>();
                x.EnableServiceRecovery(r => r.RestartService(TimeSpan.FromSeconds(10).Seconds));
                x.SetServiceName("Worker");
                x.StartAutomatically(); CreateHostBuilder(args).Build(); });
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            OlivaTaxiWebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
