using AutoMapper;

namespace RealEstateCatalog.WebApi.Mappings;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<City, CityDto>().ReverseMap();
        CreateMap<City, KeyValuePairDto>().ReverseMap();
    }
}
