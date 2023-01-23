using AutoMapper;

namespace RealEstateCatalog.WebApi.Mappings;

public class PropertyTypeProfile : Profile
{
	public PropertyTypeProfile()
	{
		CreateMap<PropertyType, KeyValuePairDto>().ReverseMap();
	}
}
