using AutoMapper;
using DB.Entities;

namespace DB.UnitOfWork;

public interface IRepository<TEntity> where TEntity : class, IEntity<Guid>
{
    IQueryable<TEntity> Get();
    void Delete(Guid entityId);
    Task<TEntity> InsertOrUpdateAsync<TModel>(
        TModel model,
        IMapper mapper,
        CancellationToken cancellationToken = default) where TModel : class;
}