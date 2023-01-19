using AutoMapper;

namespace RealEstateCatalog.WebApi.Mappings;

public class PropertyProfile : Profile
{
	public PropertyProfile()
	{
		CreateMap<Property, PropertyListDto>()
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.SellRent, opt => opt.MapFrom(src => src.SellRent))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.PropertyType, opt => opt.MapFrom(src => src.PropertyType.Name))
            .ForMember(dest => dest.FurnishingType, opt => opt.MapFrom(src => src.FurnishingType.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.BHK, opt => opt.MapFrom(src => src.BHK))
            .ForMember(dest => dest.BuildArea, opt => opt.MapFrom(src => src.BuildArea))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
            .ForMember(dest => dest.ReadyToMove, opt => opt.MapFrom(src => src.ReadyToMove))
            .ForMember(dest => dest.EstPossessionOn, opt => opt.MapFrom(src => src.EstPossessionOn));

        CreateMap<Property, PropertyDetailDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.PropertyType, opt => opt.MapFrom(src => src.PropertyType.Name))
            .ForMember(dest => dest.FurnishingType, opt => opt.MapFrom(src => src.FurnishingType.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.BHK, opt => opt.MapFrom(src => src.BHK))
            .ForMember(dest => dest.BuildArea, opt => opt.MapFrom(src => src.BuildArea))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
            .ForMember(dest => dest.ReadyToMove, opt => opt.MapFrom(src => src.ReadyToMove))
            .ForMember(dest => dest.EstPossessionOn, opt => opt.MapFrom(src => src.EstPossessionOn));
    }
}
