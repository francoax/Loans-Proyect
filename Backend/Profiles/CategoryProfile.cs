using AutoMapper;
using Backend.Dto;
using Backend.Entities;

namespace Backend.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryForCreationDto, Category>()
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => $"{src.Description}")
                    );
        }
    }
}
