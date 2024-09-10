using MyCv.Application.Interfaces.IRepository;
using MyCv.Domain.Entities.Client;
using MyCv.İnfracture;

namespace MyCv.Infrastructure.Repositories.Repository
{
    public class WriteRepository : IWriteRepository
    {
        private readonly ApplicationDbContext _context;

        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task AddAsync(Client client)
        {
            await _context.Set<Client>().AddAsync(client);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<Client> UpdateAsync(Client client)
        {
            _context.Set<Client>().Update(client);
            await _context.SaveChangesAsync();
            return client;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var client = await _context.Set<Client>().FindAsync(id);
            _context.Set<Client>().Remove(client);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}

