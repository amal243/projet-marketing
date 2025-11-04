// ICampagneRepository.cs
using gestion_marketing.Models;

namespace gestion_marketing.DAL.Interfaces
{
    public interface ICampagneRepository
    {
        Task<IEnumerable<Campagne>> GetAllAsync();
        Task<Campagne?> GetByIdAsync(int id);
        Task<Campagne> AddAsync(Campagne campagne);
        Task<bool> UpdateAsync(Campagne campagne);
        Task<bool> DeleteAsync(int id);
    }
}
