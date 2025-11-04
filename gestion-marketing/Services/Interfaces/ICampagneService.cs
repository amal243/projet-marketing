using gestion_marketing.DTOs;

namespace gestion_marketing.Services.Interfaces
{
    public interface ICampagneService
    {
        Task<IEnumerable<CampagneDto>> GetAllAsync();
        Task<CampagneDto?> GetByIdAsync(int id);
        Task<CampagneDto> CreateAsync(CreateCampagneDto dto);
        Task<bool> UpdateAsync(int id, UpdateCampagneDto dto);
        Task<bool> DeleteAsync(int id);
    }
}