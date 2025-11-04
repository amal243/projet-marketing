// IClientRepository.cs
using gestion_marketing.Models;

namespace gestion_marketing.DAL.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
        Task<Client> AddAsync(Client client);
        Task<bool> UpdateAsync(Client client);
        Task<bool> DeleteAsync(int id);
    }
}
