using RealEstateCatalog.Core.Domain.Dtos;

namespace RealEstateCatalog.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

	public UserRepository(ApplicationDbContext dbContext)
	{
        _dbContext = dbContext;
	}

    public async Task<User?> AuthenticateAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<User>().FirstOrDefaultAsync(i => 
            i.Username.Equals(loginRequestDto.Username) && 
            i.Password.Equals(loginRequestDto.Password),
            cancellationToken);
    }
}
