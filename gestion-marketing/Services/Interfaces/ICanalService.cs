using gestion_marketing.Models;

namespace gestion_marketing.Services.Interfaces
{
    public interface ICanalService
    {
        Task<IEnumerable<Canal>> GetAllAsync();
        Task<Canal?> GetByIdAsync(int id);
        Task<Canal> CreateAsync(Canal canal);
        Task<bool> UpdateAsync(int id, Canal canal);
        Task<bool> DeleteAsync(int id);
    }
}
