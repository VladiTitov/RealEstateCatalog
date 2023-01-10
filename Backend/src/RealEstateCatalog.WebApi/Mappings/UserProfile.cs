using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using RealEstateCatalog.Core.Domain.Dtos;
using RealEstateCatalog.Core.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstateCatalog.WebApi.Mappings;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<User, LoginResponseDto>()
			.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
			.ForMember(dest => dest.Token, opt => opt.MapFrom(src => CreateJWT(src)));
	}

	private string CreateJWT(User user)
	{
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
		var claims = new Claim[]
		{
			new Claim(ClaimTypes.Name, user.Username),
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
		};

		var signingCredentials = new SigningCredentials(
			key, 
			SecurityAlgorithms.HmacSha256Signature);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.UtcNow.AddDays(10),
			SigningCredentials = signingCredentials
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}
}
