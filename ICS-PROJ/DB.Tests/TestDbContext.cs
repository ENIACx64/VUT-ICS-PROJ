using DB.Contexts;
using DB.Tests.Seeds;
using Microsoft.EntityFrameworkCore;

namespace DB.Tests
{
    internal class TestDbContext : ProjectDbContext
    {
        public TestDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CarSeeds.Seed(modelBuilder);
            RideSeeds.Seed(modelBuilder);
            UserSeeds.Seed(modelBuilder);

        }
    }
}
