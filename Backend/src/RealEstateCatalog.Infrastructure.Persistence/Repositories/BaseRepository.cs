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

    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await _dbContext.Set<TEntity>().FirstOrDefaultAsync(i => i.Id.Equals(id), cancellationToken);

    public TEntity Create(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        return entity;
    }

    public void Update(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }
}
