using MyCv.Application.Interfaces.ICacheRepository;
using StackExchange.Redis;
using System.Text.Json;

namespace MyCv.Infrastructure.Repositories.CacheRepository
{

    public class WriteCacheRepository : IWriteCacheRepostory
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public WriteCacheRepository(IConnectionMultiplexer redis, IDatabase database)
        {
            _redis = redis;
            _database = database;
        }

        public async Task CreateAsync<Admin>(Admin admin, Guid id)
        {
            var serializedValue=JsonSerializer.Serialize(admin);
            await _database.StringSetAsync(id.ToString(), serializedValue);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _database.KeyDeleteAsync(id.ToString());
        }

        public async Task UpdateAsync<Admin>(Guid id, Admin admin)
        {

            var serializedValue = JsonSerializer.Serialize(admin);
            await _database.StringSetAsync(id.ToString(), serializedValue);
        }
    }
}
