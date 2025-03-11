using Microsoft.Extensions.Caching.Memory;

namespace CachingMemory.Repositories.Cache.Memory;

public class CacheMemory : ICacheMemory
{
    private readonly IMemoryCache _memoryCache;

    public CacheMemory(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public string? Get(string key)
    {
        key = SetKey(key);
        _memoryCache.TryGetValue(key, out string? value);
        return value;
    }

    public void Set(string key, string data, int minutesToExpiration = 5)
    {
        key = SetKey(key);
        _memoryCache.Remove(key);
        _memoryCache.Set(key, data, new MemoryCacheEntryOptions
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(minutesToExpiration)
        });
    }

    private string SetKey(string key)
    {
        key = $"CacheMemory-{key}";
        return key;
    }
}