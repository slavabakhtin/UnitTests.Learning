using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TopCase.OlivaTaxi.Api.Common
{
    public abstract class DictionaryDataSeeder<TContext> where TContext : DbContext
    {
        protected readonly ILogger Logger;
        protected readonly TContext Context;

        public DictionaryDataSeeder(ILogger logger, TContext context)
        {
            Logger = logger;
            Context = context;
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