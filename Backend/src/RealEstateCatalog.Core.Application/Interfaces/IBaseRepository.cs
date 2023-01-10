namespace RealEstateCatalog.Core.Application.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    TEntity Create(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
}
