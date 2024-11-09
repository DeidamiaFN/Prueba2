using backend.dtos;
using backend.entities;

namespace backend.profiles;

public class PetProfile : AutoMapper.Profile
{
  public PetProfile()
  {
    CreateMap<Pet, PetDto>();
    CreateMap<(PetNoDto pet, Guid id), Pet>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.pet.Name))
      .ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.pet.Species))
      .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.pet.PersonId));
  }
  
}
