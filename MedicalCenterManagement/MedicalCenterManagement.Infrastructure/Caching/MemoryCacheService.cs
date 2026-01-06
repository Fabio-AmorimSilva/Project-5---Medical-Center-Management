namespace MedicalCenterManagement.Infrastructure.Caching;

public class MemoryCacheService : ICacheService
{
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _defaultExpiration = TimeSpan.FromMinutes(10);

    public MemoryCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task<T?> GetAsync<T>(string key)
    {
        var value = _cache.Get<T>(key);
        
        return Task.FromResult(value);
    }

    public Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
    {
        var expirationTimeSpan = expiration ?? _defaultExpiration;
        
        _cache.Set(key, value, expirationTimeSpan);
        
        return Task.CompletedTask;
    }

    public Task RemoveAsync(string key)
    {
        _cache.Remove(key);
        
        return Task.CompletedTask;
    }
}