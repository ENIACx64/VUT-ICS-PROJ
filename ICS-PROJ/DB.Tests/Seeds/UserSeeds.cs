using DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DB.Tests.Seeds;

public static class UserSeeds
{
    public static readonly UserEntity User1 = new(ID: Guid.Parse("{65E52BF9-3892-4CFF-B76C-F051BE5A07AB}"),
        Name: "Anastasia",
        Surname: "Lebedenko",
        Photo: "lady_gaga_1.jpg"
   )
    {
         OwnedCars = new List<CarEntity> { CarSeeds.MiniCooper },
         //PassengerRides = new [] { RideSeeds.Ride1 },
    };


    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasData(
            User1);
    }
}
