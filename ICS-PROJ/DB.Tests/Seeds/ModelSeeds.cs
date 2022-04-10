using BL.Models;
using System;

namespace DB.Tests.Seeds
{
    internal static class ModelSeeds
    {
        public static CarDetailModel CarDetailModel => new CarDetailModel
        {
            ID = Guid.Parse("{DE7A8123-2624-402C-BB68-30BEFECE0291}"),
            DateOfRegistration = new DateTime(2021, 08, 13),
            Manufacturer = "Zaporozec",
            Model = "M6",
            NumberOfSeats = 5,
            Photo = "https://d62-a.sdn.cz/d_62/c_img_QK_N/pN5b/Hyan-Zaz-Zaporozec.jpeg?fl=cro,0,118,2362,1328%7Cres,1200,,1%7Cwebp,75",
            Type = Enums.CarType.Saloon
        };

        public static RideDetailModel RideDetailModel => new RideDetailModel
        {
            ID = Guid.Parse("{FA4FF1E9-D72F-4859-8F4B-1FD3EF56046F}"),
            EndLocation = "Rome",
            StartLocation = "Naples",
            TimeOfArrival = new DateTime(2021, 12, 01, 15, 40, 00),
            TimeOfDeparture = new DateTime(2021, 12, 01, 08, 19, 00)
        };

        public static UserDetailModel UserDetailModel => new UserDetailModel
        {
            ID = Guid.Parse("{D6774EFE-28EA-4796-B0C1-FDE3F534D9D4}"),
            Name = "Denis",
            Surname = "Bakham",
            Photo = "abrakadabra.jpg"
        };
    }
}
