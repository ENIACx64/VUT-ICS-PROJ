using AutoMapper;
using BL.Models;
using DB.Entities;
using DB.UnitOfWork;

namespace BL.Facades
{
    public class UserFacade : CRUDFacade<UserEntity, UserListModel, UserDetailModel>
    {
        public UserFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
        {

        }
    }
}
