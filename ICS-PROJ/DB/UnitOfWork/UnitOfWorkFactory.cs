using Microsoft.EntityFrameworkCore;

namespace DB.UnitOfWork;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IDbContextFactory<DbContext> _dbContextFactory;

    public UnitOfWorkFactory(IDbContextFactory<DbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    public IUnitOfWork Create() => new UnitOfWork(_dbContextFactory.CreateDbContext());
}