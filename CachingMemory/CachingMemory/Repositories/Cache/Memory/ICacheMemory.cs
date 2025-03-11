namespace CachingMemory.Repositories.Cache.Memory;

public interface ICacheMemory
{
    string? Get(string key);
    void Set(string key, string data, int minutesToExpiration = 5);
}