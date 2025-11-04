using AutoMapper;
using gestion_marketing.DAL.Interfaces;
using gestion_marketing.DTOs;
using gestion_marketing.Models;
using gestion_marketing.Services.Interfaces;

namespace gestion_marketing.Services.Implementations
{
    public class CampagneService : ICampagneService
    {
        private readonly ICampagneRepository _repository;
        private readonly IMapper _mapper;

        public CampagneService(ICampagneRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CampagneDto>> GetAllAsync()
        {
            var campagnes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CampagneDto>>(campagnes);
        }

        public async Task<CampagneDto?> GetByIdAsync(int id)
        {
            var campagne = await _repository.GetByIdAsync(id);
            return _mapper.Map<CampagneDto?>(campagne);
        }

        public async Task<CampagneDto> CreateAsync(CreateCampagneDto dto)
        {
            var campagne = _mapper.Map<Campagne>(dto);
            await _repository.AddAsync(campagne);
            return _mapper.Map<CampagneDto>(campagne);
        }

        public async Task<bool> UpdateAsync(int id, UpdateCampagneDto dto)
        {
            var campagne = await _repository.GetByIdAsync(id);
            if (campagne == null) return false;

            _mapper.Map(dto, campagne);
            return await _repository.UpdateAsync(campagne);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
