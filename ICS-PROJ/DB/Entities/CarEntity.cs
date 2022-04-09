using System;
using System.Collections.Generic;
using System.Text;
using DB.Enums;

namespace DB.Entities
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="Manufacturer"></param>
    /// <param name="Model"></param>
    /// <param name="Type"></param>
    /// <param name="DateOfRegistration"></param>
    /// <param name="Photo"></param>
    /// <param name="NumberOfSeats"></param>
    public record CarEntity(Guid ID,
        string Manufacturer,
        string Model,
        CarType Type,
        DateTime DateOfRegistration,
        string? Photo,
        int NumberOfSeats) : IEntity<Guid>
    {
        /// <summary>
        /// Represents the owner of the car
        /// </summary>
        public UserEntity? Owner;
        /// <summary>
        /// Stores the ID of the owner
        /// </summary>
        public Guid? OwnerID;
        /// <summary>
        /// Collection of rides for this car
        /// </summary>
        public ICollection<RideEntity>? Rides { get; init; } = new List<RideEntity>();
    }
}
