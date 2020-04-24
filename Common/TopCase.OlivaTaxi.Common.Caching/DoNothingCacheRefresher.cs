using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TopCase.OlivaTaxi.Common.Caching
{
    public class DoNothingCacheRefresher<TKey, TValue> : CacheRefresher<TKey, TValue>
    {
        private readonly ILogger<DoNothingCacheRefresher<TKey, TValue>> _logger;

        public DoNothingCacheRefresher(ILogger<DoNothingCacheRefresher<TKey, TValue>> logger)
        {
            _logger = logger;
        }

        public override Task<TValue> RenewValue(TKey key)
        {
            _logger.LogInformation("Current cache implementation doesn't implement value renewal.");
            return Task.FromResult(default(TValue));
        }
    }
}