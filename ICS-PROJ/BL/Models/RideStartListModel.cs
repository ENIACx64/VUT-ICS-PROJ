using AutoMapper;
using DB.Entities;

namespace BL.Models
{
    public class RideStartListModel : IModel<Guid>
    {
        public Guid ID { get; set; }
        public string? StartLocation { get; set; }

        public class RideMapperProfile : Profile
        {
            public RideMapperProfile()
            {
                CreateMap<RideEntity, RideStartListModel>();
            }
        }
    }
}
