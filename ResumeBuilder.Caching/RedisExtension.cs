using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResumeBuilder.Caching
{
    public static class RedisExtension
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, string recordid, T data, TimeSpan? absoluteexpiretime, TimeSpan? unusedexpiretime)
        {
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteexpiretime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = unusedexpiretime;

            var json = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordid, json, options);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordid)
        {
            try
            {
                var val = cache;
                var json = await cache.GetStringAsync(recordid);
                if (json is null)
                    return default(T);
                else
                    return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception)
            {
                return default(T);
            }
            
        }
    }
}
