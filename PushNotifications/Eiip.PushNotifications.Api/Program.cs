using Eiip.Api.Common;
using Eiip.Api.Common.Extensions;
using Eiip.PushNotifications.Database;
using Microsoft.AspNetCore.Hosting;
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
            EiipWebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
