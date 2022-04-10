using System;
using System.Collections.Generic;
using System.Text;
using DB.Entities;
using BL.Models;
using DB.UnitOfWork;
using AutoMapper;

namespace BL.Facades
{
    public class RideStartFacade : CRUDFacade<RideEntity, RideStartListModel, RideDetailModel>
    {
        public RideStartFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
        {

        }
    }
}