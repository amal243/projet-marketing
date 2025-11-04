using gestion_marketing.DAL.Interfaces;
using gestion_marketing.Models;
using gestion_marketing.Data;
using Microsoft.EntityFrameworkCore;

namespace gestion_marketing.DAL.Repositories
{
    public class CanalRepository : ICanalRepository
    {
        private readonly AppDbContext _context;

        public CanalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Canal>> GetAllAsync()
        {
            return await _context.Canaux.ToListAsync();
        }

        public async Task<Canal?> GetByIdAsync(int id)
        {
            return await _context.Canaux.FindAsync(id);
        }

        public async Task<Canal> AddAsync(Canal canal)
        {
            _context.Canaux.Add(canal);
            await _context.SaveChangesAsync();
            return canal;
        }

        public async Task<bool> UpdateAsync(Canal canal)
        {
            _context.Canaux.Update(canal);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var canal = await _context.Canaux.FindAsync(id);
            if (canal == null)
                return false;

            _context.Canaux.Remove(canal);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
