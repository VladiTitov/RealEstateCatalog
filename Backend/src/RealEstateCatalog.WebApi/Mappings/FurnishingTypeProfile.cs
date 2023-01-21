using AutoMapper;

namespace RealEstateCatalog.WebApi.Mappings;

public class FurnishingTypeProfile : Profile
{
	public FurnishingTypeProfile()
	{
		CreateMap<FurnishingType, KeyValuePairDto>().ReverseMap();
	}
}
