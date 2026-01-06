namespace MedicalCenterManagement.Infrastructure.Caching;

public class RedisCacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly TimeSpan _defaultExpiration = TimeSpan.FromMinutes(10);

    public RedisCacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
    
    
    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _distributedCache.GetStringAsync(key);
        
        return string.IsNullOrWhiteSpace(value) ? default : JsonSerializer.Deserialize<T>(value, _jsonSerializerOptions);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
    {
        var expirationTime = expiration ?? _defaultExpiration;

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expirationTime
        };
        
        await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value, _jsonSerializerOptions), options);
    }

    public async Task RemoveAsync(string key)
    {
        await _distributedCache.RemoveAsync(key);
    }
}