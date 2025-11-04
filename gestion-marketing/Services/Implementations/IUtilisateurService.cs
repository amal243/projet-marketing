using gestion_marketing.DAL.Interfaces;
using gestion_marketing.Models;
using gestion_marketing.Services.Interfaces;

namespace gestion_marketing.Services.Implementations
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _repository;

        public UtilisateurService(IUtilisateurRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Utilisateur>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Utilisateur?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Utilisateur> CreateAsync(Utilisateur utilisateur) => await _repository.AddAsync(utilisateur);
        public async Task<bool> UpdateAsync(int id, Utilisateur utilisateur)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Nom = utilisateur.Nom;
            existing.Email = utilisateur.Email;
            existing.Role = utilisateur.Role;

            return await _repository.UpdateAsync(existing);
        }
        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
