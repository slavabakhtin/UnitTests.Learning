using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TopCase.OlivaTaxi.Common.Caching
{
    public abstract class CacheDbRefresher<TKey, TValue, TContext> : CacheRefresher<TKey, TValue>
    {
        private readonly IServiceProvider _serviceProvider;

        protected CacheDbRefresher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override async Task<TValue> RenewValue(TKey key)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TContext>();
            return await RenewValue(context, key);
        }

        public abstract Task<TValue> RenewValue(TContext context, TKey key);
    }
}