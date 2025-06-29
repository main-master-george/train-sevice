using StackExchange.Redis;

namespace Infrastructure.Storages;

public class RedisStorage
{
    private readonly ConnectionMultiplexer _connection;

    public RedisStorage(string endpoint, string password)
    {
        var configuration = new ConfigurationOptions
        {
            EndPoints = { endpoint },
            AllowAdmin = true,
            SyncTimeout = 5000,
            ConnectTimeout = 5000,
            Password = password,
            AbortOnConnectFail = false
        };

        _connection = ConnectionMultiplexer.Connect(configuration);
    }

    public async Task Set(string key, string value)
    {
        var database = _connection.GetDatabase();
        await database.StringSetAsync(key, value, TimeSpan.FromMinutes(10));
    }

    public async Task<string?> GetWithTimeUpdate(string key)
    {
        try
        {
            var database = _connection.GetDatabase();
            var value = await database.StringGetAsync(key);
        
            if (!value.IsNull)
            {
                await database.StringSetAsync(key, value, TimeSpan.FromHours(3));
            }
        
            return value;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}