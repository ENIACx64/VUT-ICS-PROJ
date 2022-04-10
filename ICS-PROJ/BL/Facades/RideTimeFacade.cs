using System;
using System.Collections.Generic;
using System.Text;
using DB.Entities;
using BL.Models;
using DB.UnitOfWork;
using AutoMapper;

namespace BL.Facades
{
    public class RideTimeFacade : CRUDFacade<RideEntity, RideTimeListModel, RideDetailModel>
    {
        public RideTimeFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
        {

        }
    }
}