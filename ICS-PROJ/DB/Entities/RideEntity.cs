using System;
using System.Collections.Generic;
using System.Text;

namespace DB
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="RideID"></param>
    /// <param name="StartLocation"></param>
    /// <param name="EndLocation"></param>
    /// <param name="TimeOfDeparture"></param>
    /// <param name="TimeOfArrival"></param>
    public record RideEntity(Guid RideID,
        string StartLocation,
        string EndLocation,
        DateTime TimeOfDeparture,
        DateTime TimeOfArrival)
    {
        /// <summary>
        /// Represents the car
        /// </summary>
        public CarEntity? Car;
        /// <summary>
        /// Represents the driver
        /// </summary>
        public UserEntity? Driver;
        /// <summary>
        /// Collection of passengers
        /// </summary>
        public ICollection<UserEntity>? Passengers { get; init; } = new List<UserEntity>();
    }
}