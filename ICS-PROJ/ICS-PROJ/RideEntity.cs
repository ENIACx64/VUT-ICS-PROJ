using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_PROJ
{
    internal class RideEntity
    {
        public Guid RideID { get; private set; }
        public string StartLocation { get; private set; }
        public string EndLocation { get; private set; }
        public DateTime TimeOfDeparture { get; private set; }
        public DateTime TimeOfArrival { get; private set; }
    }
}
