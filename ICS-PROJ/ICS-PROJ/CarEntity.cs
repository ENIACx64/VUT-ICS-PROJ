using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_PROJ
{
    /// <summary>
    /// Enum for different car types
    /// </summary>
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
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="LicensePlate"></param>
    /// <param name="Manufacturer"></param>
    /// <param name="Model"></param>
    /// <param name="Type"></param>
    /// <param name="DateOfRegistration"></param>
    /// <param name="Photo"></param>
    /// <param name="NumberOfSeats"></param>
    public record CarEntity(string LicensePlate,
        string Manufacturer,
        string Model,
        CarType Type,
        DateTime DateOfRegistration,
        string? Photo,
        int NumberOfSeats)
    {
        /// <summary>
        /// Represents the owner of the car
        /// </summary>
        public UserEntity? Owner;
        /// <summary>
        /// Collection of rides for this car
        /// </summary>
        public ICollection<RideEntity>? Rides { get; init; } = new List<RideEntity>();
    }
}
