using AutoMapper;
using RealEstateCatalog.Core.Domain.Dtos;
using RealEstateCatalog.Core.Domain.Models;

namespace RealEstateCatalog.WebApi.Mappings;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<User, LoginResponseDto>()
			.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
			.ForMember(dest => dest.Token, opt => opt.MapFrom(src => "Token to be generated"));
	}
}
