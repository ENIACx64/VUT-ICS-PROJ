using AutoMapper;
using DB.Entities;

namespace BL.Models
{
    public class RideTimeListModel : IModel<Guid>
    {
        public Guid ID { get; set; }
        public DateTime TimeOfDeparture { get; set; }

        public class RideMapperProfile : Profile
        {
            public RideMapperProfile()
            {
                CreateMap<RideEntity, RideTimeListModel>();
            }
        }
    }
}
