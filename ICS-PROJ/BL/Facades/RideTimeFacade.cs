using AutoMapper;
using BL.Models;
using DB.Entities;
using DB.UnitOfWork;

namespace BL.Facades
{
    public class RideTimeFacade : CRUDFacade<RideEntity, RideTimeListModel, RideDetailModel>
    {
        public RideTimeFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
        {

        }
    }
}