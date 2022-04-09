
using DB.Contexts;
using DB.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace DB.Tests
{
    public class ConnectionTests : BaseTest<IProjectDbContext>
    {
        public ConnectionTests()
        {
            var dBContextOptions = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseInMemoryDatabase(nameof(ProjectDbContextTests));

            var context = new TestDbContext(dBContextOptions.Options);

            context.RideEntities.Add(RideSeeds.Ride1);
            context.CarEntities.Add(CarSeeds.MiniCooper);
            context.UserEntities.Add(UserSeeds.User1);
            context.SaveChanges();

            SUT = context;
        }

        [Fact]
        public void Connection()
        {
            Assert.True(SUT.RideEntities.ToArray().Any());
        }
    }
}