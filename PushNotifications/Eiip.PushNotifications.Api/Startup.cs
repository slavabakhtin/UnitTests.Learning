using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TopCase.OlivaTaxi.Api.Common;
using TopCase.OlivaTaxi.Api.Common.Extensions;
using TopCase.OlivaTaxi.PushNotifications.Database;

namespace Eiip.PushNotifications.Api
{
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(configuration, webHostEnvironment)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddOlivaTaxiContext<PushNotificationsDbContext>(Configuration);
        }
    }
}
