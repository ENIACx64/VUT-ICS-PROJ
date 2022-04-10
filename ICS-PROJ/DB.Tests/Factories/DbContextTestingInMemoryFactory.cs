using DB.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DB.Tests.Factories
{
    public class DbContextTestingInMemoryFactory: IDbContextFactory<ProjectDbContext>
    {
        private readonly string _databaseName;

        public DbContextTestingInMemoryFactory(string databaseName)
        {
            _databaseName = databaseName;
        }

        public ProjectDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<ProjectDbContext> contextOptionsBuilder = new();
            contextOptionsBuilder.UseInMemoryDatabase(_databaseName);
            return new TestDbContext(contextOptionsBuilder.Options);
        }
    }
}