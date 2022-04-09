using System;
using System.Collections.Generic;
using System.Text;
using DB.Enums;
using DB.Entities;
using AutoMapper;

namespace BL.Models
{
    public class CarListModel : IModel<Guid>
    {
        public Guid ID { get; set; }
        public string? Model { get; set; }
        public CarType Type { get; set; }

        public class CarMapperProfile : Profile
        {
            public CarMapperProfile()
            {
                CreateMap<CarEntity, CarListModel>();
            }
        }
    }
}
