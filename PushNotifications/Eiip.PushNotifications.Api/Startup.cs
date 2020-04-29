using Eiip.Api.Common;
using Eiip.Api.Common.Extensions;
using Eiip.PushNotifications.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<DbMigrator<PushNotificationsDbContext>>();
            services.AddEiipContext<PushNotificationsDbContext>(Configuration);
        }
    }
}
