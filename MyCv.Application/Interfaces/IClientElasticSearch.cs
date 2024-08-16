using MyCv.Domain.Entities;

namespace MyCv.Application.Interfaces
{
    public interface  IClientElasticSearch
    {
        Task CreateClientAsync(Client client);
        Task<List<Client>> GetClientByIdAsync(Guid id);
        Task<Client> UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid id);
        Task SaveChangeAsync();
    }
}
