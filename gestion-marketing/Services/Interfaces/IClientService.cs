using System.Collections.Generic;
using System.Threading.Tasks;
using gestion_marketing.DTOs;

namespace gestion_marketing.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<ClientDto?> GetByIdAsync(int id);
        Task<ClientDto> CreateAsync(CreateClientDto dto);
        Task<ClientDto?> UpdateAsync(int id, UpdateClientDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
