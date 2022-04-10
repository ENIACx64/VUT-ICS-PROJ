using AutoMapper;
using BL.Models;
using DB.Entities;
using DB.UnitOfWork;

namespace BL.Facades
{
    public class RideEndFacade : CRUDFacade<RideEntity, RideEndListModel, RideDetailModel>
    {
        public RideEndFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
        {

        }
    }
}
