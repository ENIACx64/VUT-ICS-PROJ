using AutoMapper;
using BL.Models;
using DB.Entities;
using DB.UnitOfWork;

namespace BL.Facades
{
    public class RideStartFacade : CRUDFacade<RideEntity, RideStartListModel, RideDetailModel>
    {
        public RideStartFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
        {

        }
    }
}