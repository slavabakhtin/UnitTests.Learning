using Eiip.Api.Common;
using Microsoft.AspNetCore.Hosting;

namespace Eiip.PushNotifications.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            EiipWebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
