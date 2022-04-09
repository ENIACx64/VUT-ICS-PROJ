using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="Name"></param>
    /// <param name="Surname"></param>
    /// <param name="Photo"></param>
    public record UserEntity(Guid UserID,
        string Name,
        string Surname,
        string? Photo)
    {
        /// <summary>
        /// Collection of owned cars
        /// </summary>
        public ICollection<CarEntity>? OwnedCars { get; init; } = new List<CarEntity>();
        /// <summary>
        /// Collection of rides driven by this user
        /// </summary>
        public ICollection<RideEntity>? DriverRides { get; init; } = new List<RideEntity>();
        /// <summary>
        /// Collection of rides that were not driven by this user
        /// </summary>
        public ICollection<RideEntity>? PassengerRides { get; init; } = new List<RideEntity>();

    }
}