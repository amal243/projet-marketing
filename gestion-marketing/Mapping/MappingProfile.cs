using AutoMapper;
using gestion_marketing.Models;
using gestion_marketing.DTOs;

namespace gestion_marketing.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //  Campagne mappings
            CreateMap<Campagne, CampagneDto>()
                .ForMember(dest => dest.CanalNom, opt => opt.MapFrom(src => src.Canal != null ? src.Canal.Nom : string.Empty))
                .ForMember(dest => dest.PublicCibleNom, opt => opt.MapFrom(src => src.PublicCible != null ? src.PublicCible.Nom : string.Empty));

            CreateMap<CreateCampagneDto, Campagne>();
            CreateMap<UpdateCampagneDto, Campagne>();

            //  Client mappings
            CreateMap<Client, ClientDto>();
            CreateMap<CreateClientDto, Client>();
            CreateMap<UpdateClientDto, Client>();
        }
    }
}
