using AutoMapper;
using Backend.Dto;
using Backend.Entities;
using Backend.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            CreateMap<Category, CategoryViewModel>()
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => $"{src.Description}"))
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}"));

            CreateMap<Category, SelectListItem>()
                .ForMember(
                dest => dest.Text,
                opt => opt.MapFrom(src => $"{src.Description}"))
                .ForMember(
                dest => dest.Value,
                opt => opt.MapFrom(src => $"{src.Id}"));
                
        }
    }
}
