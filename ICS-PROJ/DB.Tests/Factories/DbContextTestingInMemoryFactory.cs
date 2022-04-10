using DB.Contexts;
using DB.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DB.Tests.Factories
{
    public class DbContextTestingInMemoryFactory: IDbContextFactory<DbContext>
    {
        private readonly string _databaseName;

        public DbContextTestingInMemoryFactory(string databaseName)
        {
            _databaseName = databaseName;
        }

        public DbContext CreateDbContext()
        {
            DbContextOptionsBuilder<ProjectDbContext> contextOptionsBuilder = new();
            contextOptionsBuilder.UseInMemoryDatabase(_databaseName);
            var context = new TestDbContext(contextOptionsBuilder.Options);

            try
            {
                if (!context.RideEntities.Any())
                    context.RideEntities.Add(RideSeeds.Ride1);

                if (!context.CarEntities.Any())
                    context.CarEntities.Add(CarSeeds.MiniCooper);

                if (!context.UserEntities.Any())
                    context.UserEntities.Add(UserSeeds.User1);

            }catch(Exception e)
            {

            }
            context.SaveChanges();

            return context;
        }
    }
}