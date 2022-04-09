using System;
using System.Collections.Generic;
using System.Text;
using DB.Entities;
using AutoMapper;

namespace BL.Models
{
    public class UserDetailModel : IModel<Guid>
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Photo { get; set; }

        public class UserMapperProfile : Profile
        {
            public UserMapperProfile()
            {
                CreateMap<UserEntity, UserListModel>();
            }
        }
    }
}
