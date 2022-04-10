using System;
using System.Collections.Generic;
using System.Text;
using DB.Entities;
using BL.Models;
using DB.UnitOfWork;
using AutoMapper;

namespace BL.Facades
{
    public class RideEndFacade : CRUDFacade<RideEntity, RideEndListModel, RideDetailModel>
    {
        public RideEndFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
        {

        }
    }
}
