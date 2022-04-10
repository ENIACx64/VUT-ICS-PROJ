using AutoMapper;
using DB.Entities;

namespace BL.Models
{
    public class UserListModel : IModel<Guid>
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public class UserMapperProfile : Profile
        {
            public UserMapperProfile()
            {
                CreateMap<UserEntity, UserListModel>();
            }
        }
    }
}
