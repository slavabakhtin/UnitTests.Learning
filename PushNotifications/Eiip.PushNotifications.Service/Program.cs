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
            HostFactory.Run(x => { CreateHostBuilder(args).Build(); });
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            OlivaTaxiWebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
