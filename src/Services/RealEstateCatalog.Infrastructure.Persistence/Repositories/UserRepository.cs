using System.Security.Cryptography;
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
        var user = await _dbContext.Set<User>().FirstOrDefaultAsync(i => i.Username.Equals(loginRequestDto.Username), cancellationToken);
        return user is not null || user?.PasswordKey is not null
            ? MatchPasswordHash(user, loginRequestDto)
                ? user
                : null
            : null;
    }

    public void Register(LoginRequestDto loginRequestDto)
    {
        byte[] passwordHash, passwordKey;
        using var hmac = new HMACSHA512();
        passwordKey = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(loginRequestDto.Password));

        var user = new User
        {
            Username = loginRequestDto.Username,
            Password = passwordHash,
            PasswordKey = passwordKey
        };

        _dbContext.Set<User>().Add(user);
    }

    public async Task<bool> UserAlreadyExistsAsync(string userName, CancellationToken cancellationToken = default)
        => await _dbContext
            .Set<User>()
            .AnyAsync(
                predicate: i => i.Username.Equals(userName), 
                cancellationToken: cancellationToken);

    private bool MatchPasswordHash(User user, LoginRequestDto loginRequestDto)
    {
        using var hmac = new HMACSHA512(user.PasswordKey);
        var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(loginRequestDto.Password));

        for (int i = 0; i < passwordHash.Length; i++)
        {
            if (passwordHash[i] != user.Password[i])
                return false;
        }
        return true;
    }
}
