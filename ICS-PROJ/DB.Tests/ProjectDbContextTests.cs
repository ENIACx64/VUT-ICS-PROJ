
using DB.Contexts;
using System.Linq;
using Xunit;

namespace DB.Tests
{
    public class ProjectDbContextTests : Bases.BaseDbContextTests<IProjectDbContext>
    {
        public ProjectDbContextTests()
        {
            SUT = DbContext.Value;
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