using Eiip.Api.Common;
using Eiip.Api.Common.Extensions;
using Eiip.PushNotifications.Database;
using Eiip.PushNotifications.Service.Fcm;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TopCase.OlivaTaxi.PushNotifications.Database;

namespace Eiip.PushNotifications.Service
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
            
            FirebaseApp.Create(new AppOptions()
            {
                ProjectId = "oliva-taxi",
                Credential = GoogleCredential.GetApplicationDefault()
            });

            services.AddContext<PushNotificationsDbContext>(Configuration);
            services.AddScoped<PushNotificationSender>();
            services.AddSingleton(FirebaseMessaging.DefaultInstance);
            services.AddScoped<FcmTokenProvider>();
            services.AddSingleton<MulticastMessageFactory>();
        }
    }
}
