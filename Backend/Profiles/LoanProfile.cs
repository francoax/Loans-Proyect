using AutoMapper;
using Backend.Dto;
using Backend.Entities;

namespace Backend.Profiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanDto>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}"))
                .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => $"{src.Status}"))
                .ForMember(
                dest => dest.Date,
                opt => opt.MapFrom(src => src.Date))
                .ForMember(
                dest => dest.ThingName,
                opt => opt.MapFrom(src => $"{src.Thing.Description}"))
                .ForMember(
                dest => dest.PersonName,
                opt => opt.MapFrom(src => $"{src.Person.Name}"))
                .ForMember(
                dest => dest.ReturnDate,
                opt => opt.MapFrom(src => $"{src.ReturnDate}"));


            CreateMap<LoanForCreationDto, Loan>()
                .ForMember(
                dest => dest.ThingId,
                opt => opt.MapFrom(src => $"{src.ThingId}"))
                .ForMember(
                dest => dest.PersonId,
                opt => opt.MapFrom(src => $"{src.PersonId}"));
            

        }
    }
}
