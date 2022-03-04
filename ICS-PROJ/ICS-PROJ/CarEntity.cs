using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_PROJ
{
    public enum CarType
    {
        None,
        Hatchback,
        Saloon,
        Coupe,
        SUV,
        Cabriolet,
        Estate,
        Van,
        Other
    }

    public record CarEntity(string LicensePlate,
        string Manufacturer,
        string Model,
        CarType Type,
        DateTime DateOfRegistration,
        string? Photo,
        int NumberOfSeats)
    {

    }
}
