// UtilisateurRepository.cs
using gestion_marketing.DAL.Interfaces;
using gestion_marketing.Models;
using gestion_marketing.Data;
using Microsoft.EntityFrameworkCore;

namespace gestion_marketing.DAL.Repositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly AppDbContext _context;

        public UtilisateurRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Utilisateur>> GetAllAsync()
        {
            return await _context.Utilisateurs.ToListAsync();
        }

        public async Task<Utilisateur?> GetByIdAsync(int id)
        {
            return await _context.Utilisateurs.FindAsync(id);
        }

        public async Task<Utilisateur> AddAsync(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Add(utilisateur);
            await _context.SaveChangesAsync();
            return utilisateur;
        }

        public async Task<bool> UpdateAsync(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Update(utilisateur);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null) return false;
            _context.Utilisateurs.Remove(utilisateur);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
