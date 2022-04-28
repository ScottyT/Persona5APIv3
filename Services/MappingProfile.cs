using AutoMapper;
using Persona5APIv3.Models;

namespace Persona5APIv3.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PersonaDTO, PersonaEntity>().ReverseMap();
        CreateMap<PersonaStatsDTO, PersonaStatsEntity>().ReverseMap();
    }
}