// ICanalRepository.cs
using gestion_marketing.Models;

namespace gestion_marketing.DAL.Interfaces
{
    public interface ICanalRepository
    {
        Task<IEnumerable<Canal>> GetAllAsync();
        Task<Canal?> GetByIdAsync(int id);
        Task<Canal> AddAsync(Canal canal);
        Task<bool> UpdateAsync(Canal canal);
        Task<bool> DeleteAsync(int id);
    }
}
