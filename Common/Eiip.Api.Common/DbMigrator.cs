using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eiip.Api.Common
{
    public class DbMigrator<TContext> where TContext : DbContext
    {
        private readonly ILogger<DbMigrator<TContext>> _logger;
        private readonly TContext _context;

        public DbMigrator(ILogger<DbMigrator<TContext>> logger, TContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Migrate(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Executing db migration...");
            try
            {
                await _context.Database.MigrateAsync(cancellationToken: stoppingToken);
                _logger.LogInformation("Db migration successfully executed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Db migration completed with error.");
            }
        }
    }
}