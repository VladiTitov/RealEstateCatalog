namespace RealEstateCatalog.Infrastructure.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
	private readonly ApplicationDbContext _dbContext;

	public BaseRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
		=> await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
}
