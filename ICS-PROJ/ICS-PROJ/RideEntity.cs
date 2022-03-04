using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_PROJ
{
    public record RideEntity(Guid RideID,
        string StartLocation,
        string EndLocation,
        DateTime TimeOfDeparture,
        DateTime TimeOfArrival)
    {

    }
}
