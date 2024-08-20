using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyCv.Application.CQRS.Command;
using MyCv.Application.Interfaces;
using MyCv.Domain.Entities;
using MyCv.İnfracture;

namespace MyCv.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ClientRepository(ApplicationDbContext context)
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
