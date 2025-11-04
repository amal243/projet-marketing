// IUtilisateurRepository.cs
using gestion_marketing.Models;

namespace gestion_marketing.DAL.Interfaces
{
    public interface IUtilisateurRepository
    {
        Task<IEnumerable<Utilisateur>> GetAllAsync();
        Task<Utilisateur?> GetByIdAsync(int id);
        Task<Utilisateur> AddAsync(Utilisateur utilisateur);
        Task<bool> UpdateAsync(Utilisateur utilisateur);
        Task<bool> DeleteAsync(int id);
    }
}
