using DB.Entities;
using DB.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace DB.Tests.Seeds;

public static class CarSeeds
{
    public static readonly CarEntity MiniCooper = new(ID: Guid.Parse("{DA20C209-B75D-4802-B6DA-C501EF5F2118}"),
      Manufacturer: "BMW",
      Model: "5",
      Type: CarType.Cabriolet,
      DateOfRegistration: new(2021, 11, 12),
      Photo: "mini_cooper_5_1.jpg",
      NumberOfSeats: 4)
    { 
            Owner = UserSeeds.User1,
            OwnerID = UserSeeds.User1.ID
    };

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarEntity>().HasData( MiniCooper );
    }

    public static readonly CarEntity EmptyCar = new(ID: Guid.Parse("{E41CADD9-D212-4F9A-9FCC-57149E659DC9}"),
      Manufacturer: default,
      Model: default,
      Type: default,
      DateOfRegistration: default,
      Photo: default,
      NumberOfSeats: default)
    {
        Owner = default,
        OwnerID = default
    };

    public static void Seed1(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarEntity>().HasData(EmptyCar);
    }
}

