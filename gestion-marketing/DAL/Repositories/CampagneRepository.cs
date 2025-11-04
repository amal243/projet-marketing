// CampagneRepository.cs
using gestion_marketing.DAL.Interfaces;
using gestion_marketing.Models;
using gestion_marketing.Data;
using Microsoft.EntityFrameworkCore;

namespace gestion_marketing.DAL.Repositories
{
    public class CampagneRepository : ICampagneRepository
    {
        private readonly AppDbContext _context;

        public CampagneRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Campagne>> GetAllAsync()
        {
            return await _context.Campagnes.ToListAsync();
        }

        public async Task<Campagne?> GetByIdAsync(int id)
        {
            return await _context.Campagnes.FindAsync(id);
        }

        public async Task<Campagne> AddAsync(Campagne campagne)
        {
            _context.Campagnes.Add(campagne);
            await _context.SaveChangesAsync();
            return campagne;
        }

        public async Task<bool> UpdateAsync(Campagne campagne)
        {
            _context.Campagnes.Update(campagne);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var campagne = await _context.Campagnes.FindAsync(id);
            if (campagne == null) return false;
            _context.Campagnes.Remove(campagne);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
