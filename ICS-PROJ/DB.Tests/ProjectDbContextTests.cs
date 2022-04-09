
using DB.Contexts;
using DB.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace DB.Tests
{
    public class ProjectDbContextTests : BaseTest<IProjectDbContext>
    {
        public ProjectDbContextTests()
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
        public void GetAll_Rides()
        {
            Assert.True(SUT.RideEntities.ToArray().Any());
        }

        [Fact]
        public void GetAll_Users()
        {
            Assert.True(SUT.UserEntities.ToArray().Any());
        }

        [Fact]
        public void GetAll_Cars()
        {
            Assert.True(SUT.CarEntities.ToArray().Any());
        }
    }
}