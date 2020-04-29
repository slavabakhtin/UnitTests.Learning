using System;
using System.Threading;
using System.Threading.Tasks;
using Eiip.Api.Common;
using Eiip.PushNotifications.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Eiip.PushNotifications.Api
{
    public class MigrateWorker : BackgroundService
    {
        private readonly ILogger<MigrateWorker> _logger;
        private readonly IServiceProvider _provider;

        public MigrateWorker(ILogger<MigrateWorker> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _provider.CreateScope().ServiceProvider.GetRequiredService<DbMigrator<PushNotificationsDbContext>>().Migrate(stoppingToken);
                _logger.LogInformation("MigrateWorker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}