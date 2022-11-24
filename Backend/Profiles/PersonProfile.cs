using AutoMapper;
using Backend.Dto;
using Backend.Entities;

namespace Backend.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonForCreationDto, Person>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )   
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src => $"{src.PhoneNumber}")
                );

            CreateMap<PersonForModificationDto, Person>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, sourceValue) => sourceValue is not (object)"" and not null));
        }

    }
}
