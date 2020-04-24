using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eiip.Api.Common
{
    public abstract class DictionaryDataSeeder<TContext> where TContext : DbContext
    {
        protected readonly ILogger Logger;

        public DictionaryDataSeeder(ILogger logger)
        {
            Logger = logger;
        }

        public async Task Seed()
        {
            Logger.LogInformation("Inserting dictionary data...");
            try
            {
                await SeedInternal();
                Logger.LogInformation("Dictionary data successfully inserted");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Dictionary data insertion failed.");
            }
        }

        protected abstract Task SeedInternal();
    }
}