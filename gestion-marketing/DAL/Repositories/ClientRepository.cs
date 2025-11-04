// ClientRepository.cs
using gestion_marketing.DAL.Interfaces;
using gestion_marketing.Models;
using gestion_marketing.Data;
using Microsoft.EntityFrameworkCore;

namespace gestion_marketing.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<bool> UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;
            _context.Clients.Remove(client);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
