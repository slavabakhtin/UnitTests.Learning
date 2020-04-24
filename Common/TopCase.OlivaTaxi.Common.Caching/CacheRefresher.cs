using System.Threading.Tasks;

namespace TopCase.OlivaTaxi.Common.Caching
{
    public abstract class CacheRefresher<TKey, TValue>
    {
        public abstract Task<TValue> RenewValue(TKey key);
    }
}