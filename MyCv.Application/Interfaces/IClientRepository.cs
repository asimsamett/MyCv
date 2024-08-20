using MyCv.Domain.Entities;

namespace MyCv.Application.Interfaces
{

    public interface IClientRepository
    {
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task AddAsync(Client client);

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns>All Datas</returns>
        Task<List<Client>> GetAllAsync();

        /// <summary>
        /// GettByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Client>GettByIdAsync(Guid id);

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task<Client> UpdateAsync(Client client);

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// SaveChangeAsync
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangeAsync();
        
    }
}
