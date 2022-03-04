using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_PROJ
{
    internal class CarEntity
    {
        public string LicensePlate { get; private set; }
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public enum Type
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
        public DateTime DateOfRegistration { get; private set; }
        public string Photo { get; private set; }
        public int NumberOfSeats { get; private set; }
    }
}
