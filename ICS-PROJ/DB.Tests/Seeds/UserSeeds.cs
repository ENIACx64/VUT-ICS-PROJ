using DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DB.Tests.Seeds;

public static class UserSeeds
{
    public static readonly UserEntity User1 = new(ID: Guid.Parse("{65E52BF9-3892-4CFF-B76C-F051BE5A07AB}"),
        Name: "Anastasia",
        Surname: "Lebedenko",
        Photo: "lady_gaga_1.jpg"
   )
    {

    };


    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasData(
            User1);
    }
}
