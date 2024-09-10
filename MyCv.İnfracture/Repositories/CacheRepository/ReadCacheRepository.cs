using MyCv.Application.Interfaces.ICacheRepository;
using MyCv.Domain.Entities.Admin;
using StackExchange.Redis;
using System.Text.Json;

namespace MyCv.Infrastructure.Repositories.CacheRepository
{
    public class ReadCacheRepository : IReadCacheRepostory
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        
        private readonly IDatabase _database;

        public ReadCacheRepository(IConnectionMultiplexer connectionMultiplexer, IDatabase database)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _database = database;
        }

        public async Task<Admin> GetByIdAsync<Admin>(Guid id)
        {
            var value = await _database.StringGetAsync(id.ToString());
            if (value.IsNullOrEmpty)
            {
                return default;
            }
            return JsonSerializer.Deserialize<Admin>(value);
        }

        
    }
}
