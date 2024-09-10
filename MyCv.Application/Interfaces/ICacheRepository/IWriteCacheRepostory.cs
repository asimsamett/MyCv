using MyCv.Domain.Entities;

namespace MyCv.Application.Interfaces.ICacheRepository
{
    public interface IWriteCacheRepostory
    { 
        Task CreateAsync<Admin>(Admin admin, Guid id);
        Task UpdateAsync<Admin>(Guid id,Admin admin);
        Task RemoveAsync(Guid id);
        
    }
}
