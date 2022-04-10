using DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DB.Tests.Seeds;

public static class RideSeeds
{
    public static readonly RideEntity Ride1 = new(ID: Guid.Parse("{7CD90215-FA8B-4E25-ACC1-A8BFC75CAEDB}"),
        StartLocation: "Valencia",
        EndLocation: "Barcelona",
        TimeOfDeparture: new(2022, 04, 15, 12, 15, 00),
        TimeOfArrival: new(2022, 04, 15, 16, 15, 00))
    {
        Car = CarSeeds.MiniCooper,
    };


    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RideEntity>().HasData(
            Ride1);
    }
}
