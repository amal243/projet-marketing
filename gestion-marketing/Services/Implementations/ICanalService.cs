using gestion_marketing.DAL.Interfaces;
using gestion_marketing.Models;
using gestion_marketing.Services.Interfaces;

namespace gestion_marketing.Services.Implementations
{
    public class CanalService : ICanalService
    {
        private readonly ICanalRepository _repository;

        public CanalService(ICanalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Canal>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Canal?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Canal> CreateAsync(Canal canal) => await _repository.AddAsync(canal);
        public async Task<bool> UpdateAsync(int id, Canal canal)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;
            existing.Nom = canal.Nom;
            return await _repository.UpdateAsync(existing);
        }
        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
