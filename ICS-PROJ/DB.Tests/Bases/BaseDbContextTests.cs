using DB.Contexts;
using DB.Tests.Factories;
using Microsoft.EntityFrameworkCore;
using System;

namespace DB.Tests.Bases;

public abstract class BaseDbContextTests<T> : BaseTests<T> , IDisposable
{
    protected Lazy<ProjectDbContext> DbContext { get; private set; }
    protected IDbContextFactory<DbContext> DbFactory { get; private set; }
    protected BaseDbContextTests()
    {
        DbFactory = new DbContextTestingInMemoryFactory(GetHashCode().ToString());
        DbContext = new Lazy<ProjectDbContext>(() =>
        {
            return (ProjectDbContext)DbFactory.CreateDbContext();
        });
    }

    public void Dispose()
    {
        DbContext.Value.Dispose();
    }
}

