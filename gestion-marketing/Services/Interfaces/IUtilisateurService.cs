using gestion_marketing.Models;

namespace gestion_marketing.Services.Interfaces
{
    public interface IUtilisateurService
    {
        Task<IEnumerable<Utilisateur>> GetAllAsync();
        Task<Utilisateur?> GetByIdAsync(int id);
        Task<Utilisateur> CreateAsync(Utilisateur utilisateur);
        Task<bool> UpdateAsync(int id, Utilisateur utilisateur);
        Task<bool> DeleteAsync(int id);
    }
}
