using System;
using System.Collections.Generic;
using System.Text;
using DB.Entities;
using BL.Models;
using DB.UnitOfWork;
using AutoMapper;

namespace BL.Facades
{
    public class CarFacade : CRUDFacade<CarEntity, CarListModel, CarDetailModel>
    {
        public CarFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
        {

        }
    }
}