using AutoMapper;
using BL.Models;
using DB.Entities;
using DB.UnitOfWork;

namespace BL.Facades
{
    public class CarFacade : CRUDFacade<CarEntity, CarListModel, CarDetailModel>
    {
        public CarFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
        {

        }
    }
}