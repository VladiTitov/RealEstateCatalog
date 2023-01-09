using AutoMapper;
using RealEstateCatalog.Core.Domain.Dtos;
using RealEstateCatalog.Core.Domain.Models;

namespace RealEstateCatalog.WebApi.Mappings;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<City, CityDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}
