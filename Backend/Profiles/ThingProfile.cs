using AutoMapper;
using Backend.Dto;
using Backend.Entities;
using Backend.Models;

namespace Backend.Profiles
{
    public class ThingProfile : Profile
    {
        public ThingProfile()
        {
            CreateMap<Thing, ThingViewModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}"))
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => $"{src.Description}"))
                .ForMember(
                    dest => dest.CategoryId,
                    opt => opt.MapFrom(src => $"{src.CategoryId}"))
                .ForMember(
                    dest => dest.CategoryDescription,
                    opt => opt.MapFrom(src => $"{src.Category.Description}"));
                

            CreateMap<ThingViewModel, Thing>()
                .ForMember(
                dest => dest.CategoryId,
                opt => opt.MapFrom(src => $"{src.CategoryId}"))
                .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => $"{src.Description}"));
        }
    }
}
