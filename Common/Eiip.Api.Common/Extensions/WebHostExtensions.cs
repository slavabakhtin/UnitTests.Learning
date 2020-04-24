using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eiip.Api.Common.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrateDb<TContext>(this IWebHost webHost) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<DbMigrator<TContext>>().Migrate().Wait();
                var dataSeeder = scope.ServiceProvider.GetService<DictionaryDataSeeder<TContext>>();
                dataSeeder?.Seed().Wait();
            }

            return webHost;
        }
    }
}