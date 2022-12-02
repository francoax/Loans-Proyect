using AutoMapper;
using Backend.Dto;
using Backend.Entities;

namespace Backend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForCreationDto, User>();
            CreateMap<User, UserDto>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}"))
                .ForMember(
                dest => dest.Username,
                opt => opt.MapFrom(src => $"{src.Username}"))
                .ForMember(
                dest => dest.Role,
                opt => opt.MapFrom(src => $"{src.Role.Description}"));

        }
    }
}
