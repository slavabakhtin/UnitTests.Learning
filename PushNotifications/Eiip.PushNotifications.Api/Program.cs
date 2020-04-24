using Microsoft.AspNetCore.Hosting;
using TopCase.OlivaTaxi.Api.Common;
using TopCase.OlivaTaxi.Api.Common.Extensions;
using TopCase.OlivaTaxi.PushNotifications.Database;

namespace Eiip.PushNotifications.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().MigrateDb<PushNotificationsDbContext>().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            OlivaTaxiWebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
