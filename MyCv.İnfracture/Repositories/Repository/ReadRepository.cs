using Microsoft.EntityFrameworkCore;
using MyCv.Application.Interfaces.IRepository;
using MyCv.Domain.Entities.Client;
using MyCv.İnfracture;
using Nest;

namespace MyCv.Infrastructure.Repositories.Repository
{
    public class ReadRepository : IReadRepository
    {
        private readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Client> GettByIdAsync(Guid id)
        {

            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }


    }
}

