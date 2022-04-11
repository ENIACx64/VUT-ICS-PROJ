using AutoMapper;
using DB.Entities;
using DB.Enums;

namespace BL.Models
{
    public class CarDetailModel : IModel<Guid>
    {
        public Guid ID { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public CarType Type { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string? Photo { get; set; }
        public int NumberOfSeats { get; set; }

        public class CarMapperProfile : Profile
        {
            public CarMapperProfile()
            {
                CreateMap<CarEntity, CarDetailModel>().ReverseMap();
            }
        }
    }
}
 //test