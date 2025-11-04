using AutoMapper;
using gestion_marketing.DAL.Interfaces;
using gestion_marketing.DTOs;
using gestion_marketing.Models;
using gestion_marketing.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestion_marketing.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //  Récupérer tous les clients
        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var clients = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        //  Récupérer un client par ID
        public async Task<ClientDto?> GetByIdAsync(int id)
        {
            var client = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClientDto?>(client);
        }

        //  Créer un nouveau client
        public async Task<ClientDto> CreateAsync(CreateClientDto dto)
        {
            var client = _mapper.Map<Client>(dto);
            await _repository.AddAsync(client);
            return _mapper.Map<ClientDto>(client);
        }

        //  Mettre à jour un client existant
        public async Task<ClientDto?> UpdateAsync(int id, UpdateClientDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);

            return _mapper.Map<ClientDto>(existing);
        }

        //  Supprimer un client
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
