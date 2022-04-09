using System;
using System.Collections.Generic;
using System.Text;
using DB.Enums;

namespace DB.Models.Car
{
    public class CarListModel
    {
        public Guid ID;
        public string? Manufacturer;
        public string? Model;
        public CarType Type;
    }
}
