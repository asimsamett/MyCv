using MyCv.Domain.Entities.Client;

namespace MyCv.Application.Interfaces.IRepository
{
    public interface IWriteRepository
    {
        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task AddAsync(Client client);

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
