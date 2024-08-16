using MyCv.Domain.Entities;

namespace MyCv.Application.Interfaces
{
    public interface IClientRepository
    {
        Task AddAsync(Client client);
        Task<List<Client>> GetAllAsync();
        Task<Client>GettByIdAsync(Guid id);
        Task<Client> UpdateAsync(Client client);
        Task DeleteAsync(Guid id);
        Task<int> SaveChangeAsync();
        
    }
}
