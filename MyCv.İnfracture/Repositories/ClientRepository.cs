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

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Client client)
        {
            await _context.Set<Client>().AddAsync(client);
            await _context.SaveChangesAsync();
        }
        public async Task<Client> GettByIdAsync(Guid id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            _context.Set<Client>().Update(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(Guid id)
        {

            var client = await _context.Set<Client>().FindAsync(id);
            _context.Set<Client>().Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
