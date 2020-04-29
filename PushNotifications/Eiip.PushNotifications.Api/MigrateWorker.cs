using System;
using System.Threading;
using System.Threading.Tasks;
using Eiip.Api.Common;
using Eiip.PushNotifications.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Eiip.PushNotifications.Api
{
    public class MigrateWorker : BackgroundService
    {
        private readonly IServiceProvider _provider;

        public MigrateWorker(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await _provider.CreateScope().ServiceProvider.GetRequiredService<DbMigrator<PushNotificationsDbContext>>()
                .Migrate(cancellationToken);
        }
    }
}