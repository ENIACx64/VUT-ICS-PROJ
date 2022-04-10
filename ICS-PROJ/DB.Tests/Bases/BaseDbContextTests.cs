
using DB.Contexts;
using DB.Tests.Factories;
using DB.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using System;

namespace DB.Tests.Bases;

public abstract class BaseDbContextTests<T> : BaseTests<T>
{
    protected Lazy<ProjectDbContext> DbContext { get; private set; }
    protected IDbContextFactory<ProjectDbContext> DbFactory { get; private set; }
  
    protected BaseDbContextTests()
    {
        DbFactory = new DbContextTestingInMemoryFactory(nameof(ProjectDbContextTests));
        DbContext = new Lazy<ProjectDbContext>(() =>
        {
            var context = DbFactory.CreateDbContext();
            context.RideEntities.Add(RideSeeds.Ride1);
            context.CarEntities.Add(CarSeeds.MiniCooper);
            context.UserEntities.Add(UserSeeds.User1);
            context.SaveChanges();
            return context;
        });
    }
}

