using backend.dtos;
using backend.entities;

namespace backend.profiles;

public class PersonaProfile : AutoMapper.Profile
{
  public PersonaProfile()
  {
    CreateMap<Persona, PersonaDto>();
    CreateMap<(PersonaNoIdDto p, Guid id), Persona>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
      .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.p.Nombre))
      .ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.p.FechaNacimiento));
  }
}