using System;
using System.Threading;
using System.Threading.Tasks;
using Eiip.Api.Common;
using Eiip.PushNotifications.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Eiip.PushNotifications.Api
{
    public class MigrateDbWorker<T> : BackgroundService where T : DbContext
    {
        private readonly IServiceProvider _provider;

        public MigrateDbWorker(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using var scope = _provider.CreateScope();
            var dbMigrator = scope.ServiceProvider.GetRequiredService<DbMigrator<T>>();
            await dbMigrator.Migrate(cancellationToken);
        }
    }
}