using AutoMapper;
using System;
using TaxiBooking.Models.DTO.CarDto;
using TaxiBooking.Models.Entities;

namespace TaxiBooking.Mapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>()
                .ForMember(dest => dest.CarColor, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.CarNo, opt => opt.MapFrom(src => src.No))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.ExpiryDate.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.Model));
            
            CreateMap<CreateCarDto, Car>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.CarColor))
                .ForMember(dest => dest.No, opt => opt.MapFrom(src => src.CarNo))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.CarModel));
            
            CreateMap<UpdateCarDto, Car>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.CarColor))
                .ForMember(dest => dest.No, opt => opt.MapFrom(src => src.CarNo))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.CarModel));
        }
    }
}