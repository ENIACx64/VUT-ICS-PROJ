﻿using System;
using System.Collections.Generic;
using System.Text;
using DB.Entities;
using AutoMapper;

namespace BL.Models
{
    public class RideEndListModel : IModel<Guid>
    {
        public Guid ID { get; set; }
        public string? EndLocation { get; set; }

        public class RideMapperProfile : Profile
        {
            public RideMapperProfile()
            {
                CreateMap<RideEntity, RideEndListModel>();
            }
        }
    }
}