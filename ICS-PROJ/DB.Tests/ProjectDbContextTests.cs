
using DB.Contexts;
using DB.Entities;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace DB.Tests
{
    public class ProjectDbContextTests : BaseTest<IProjectDbContext>
    {
        Guid userId;
        Guid rideId;

        public ProjectDbContextTests()
        {
            var dBContextOptions = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseInMemoryDatabase(nameof(ProjectDbContextTests));

            var context = new ProjectDbContext(dBContextOptions.Options);

            var date = new DateTime(2022, 1, 1, 12, 30, 0);
            rideId = Guid.NewGuid();

            context.RideEntities.Add(new RideEntity(rideId, "Kyiv", "Dnipro", date, date.AddMinutes(5)));
            context.RideEntities.Add(new RideEntity(Guid.NewGuid(), "Prague", "Brno", date, date.AddMinutes(30)));
            context.RideEntities.Add(new RideEntity(Guid.NewGuid(), "Monte", "Brno", date, date.AddMinutes(10)));

            userId = Guid.NewGuid();
            context.UserEntities.Add(new UserEntity(userId, "Anastasia", "Lebedenko", null));

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
        public void GetUserById()
        {
            var user = SUT.UserEntities.FirstOrDefault(x => x.ID == userId);

            Assert.Equal("Anastasia", user.Name);
            Assert.Equal("Lebedenko", user.Surname);
        }

        [Fact]
        public void GetRideById()
        {
            var ride = SUT.RideEntities.FirstOrDefault(x => (x.TimeOfArrival - x.TimeOfDeparture).TotalMinutes > 15);

            Assert.Equal("Prague", ride.StartLocation);
            Assert.Equal("Brno", ride.EndLocation);

        }
    }
}