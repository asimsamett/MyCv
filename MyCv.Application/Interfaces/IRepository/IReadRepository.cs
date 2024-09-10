using MyCv.Domain.Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Application.Interfaces.IRepository
{
    public interface IReadRepository
    {
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
        Task<Client> GettByIdAsync(Guid id);
    }
}
