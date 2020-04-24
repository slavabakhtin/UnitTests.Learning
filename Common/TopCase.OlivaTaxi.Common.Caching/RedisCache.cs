using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TopCase.OlivaTaxi.Common.Extensions;

namespace TopCase.OlivaTaxi.Common.Caching
{
    public abstract class RedisCache<TKey, TValue>
    {
        private readonly ILogger _logger;
        private readonly IDistributedCache _cache;
        private readonly CacheRefresher<TKey, TValue> _cacheRefresher;

        private readonly string _cachePrefix;
        private readonly string _emptyObjectCacheValue = new object().ToJson();

        protected RedisCache(ILogger logger, IDistributedCache cache, CacheRefresher<TKey, TValue> cacheRefresher)
        {
            _logger = logger;
            _cache = cache;
            _cacheRefresher = cacheRefresher;
            _cachePrefix = this.GetType().Name.Replace("Cache", "", StringComparison.Ordinal);

            _logger.LogInformation($"Initializing cache with prefix=[{_cachePrefix}]");
        }

        public async Task SetValue(TKey key, TValue value)
        {
            var cacheString = value == null ? _emptyObjectCacheValue : value.ToJson();
            await SetString(key, cacheString);
        }

        public async Task<TValue> GetValue(TKey key)
        {
            var value = await GetString(key);
            if (value == null)
            {
                _logger.LogInformation($"Value for key={key} is missing.");
                return await RenewValue(key);
            }

            if (value == _emptyObjectCacheValue)
            {
                return default;
            }

            try
            {
                return value.FromJson<TValue>();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"Cache value for key={key} is corrupted ({value.ToJson()}).");
                return await RenewValue(key);
            }
        }

        public async Task UpdateValue(TKey key, Action<TValue> updateCachedItem)
        {
            var cachedDriverProfile = await GetValue(key);
            if (cachedDriverProfile == null)
            {
                return;
            }
            updateCachedItem(cachedDriverProfile);
            await SetValue(key, cachedDriverProfile);
        }

        public async Task Invalidate(TKey key)
        {
            _logger.LogInformation($"Value for key={key} invalidated.");

            var cacheString = await GetString(key);
            if (string.IsNullOrWhiteSpace(cacheString))
            {
                _logger.LogInformation($"Value for key={key} is not loaded into cache.");
                return;
            }

            await RenewValue(key);
        }

        private async Task<TValue> RenewValue(TKey key)
        {
            _logger.LogInformation($"Renewing the value for key={key}.");

            var newValue = await _cacheRefresher.RenewValue(key);
            await SetValue(key, newValue);

            return newValue;
        }

        private async Task<string> GetString(TKey key)
        {
            var keyWithPrefix = $"{_cachePrefix}:{key}";

            _logger.LogInformation($"Retrieving {keyWithPrefix} value from cache.");
            var value = await _cache.GetStringAsync(keyWithPrefix);
            _logger.LogInformation($"Read from cache {keyWithPrefix}={value}.");

            return value;
        }

        private async Task SetString(TKey key, string value)
        {
            var keyWithPrefix = $"{_cachePrefix}:{key.ToString()}";
            _logger.LogInformation($"Setting {keyWithPrefix}={value} into cache.");
            await _cache.SetStringAsync(keyWithPrefix, value ?? string.Empty);
        }
    }
}
