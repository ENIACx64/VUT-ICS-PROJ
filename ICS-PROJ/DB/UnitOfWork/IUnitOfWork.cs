using DB.Entities;

namespace DB.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity<Guid>;
    Task CommitAsync();
}