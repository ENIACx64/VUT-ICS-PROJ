using BL.Models;
using DB.Entities;
using DB.Tests.Seeds;
using DB.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DB.Tests
{
    public class UnitOfWorkTests : Bases.BaseMapperTests<IUnitOfWork>
    {
        public UnitOfWorkTests()
        {
            SUT = new DB.UnitOfWork.UnitOfWork(DbContext.Value);
        }

        [Fact]
        public async Task UserGetRepository()
        {
            var entity = SUT.GetRepository<UserEntity>().Get().SingleOrDefault(x => x.ID == UserSeeds.User1.ID);
            Assert.NotNull(entity);
            Assert.Equal(UserSeeds.User1.ID, entity.ID);

            SUT.GetRepository<UserEntity>().Delete(UserSeeds.User1.ID);
            await SUT.CommitAsync();

            Assert.False(SUT.GetRepository<UserEntity>().Get().Any(x => x.ID == UserSeeds.User1.ID));
        }

        [Fact]
        public async Task CarInsertRepository()
        {
            var model = new CarDetailModel
            {
                ID = Guid.Parse("{DE7A8123-2624-402C-BB68-30BEFECE0291}"),
                DateOfRegistration = new DateTime(2021, 08, 13),
                Manufacturer = "Zaporozec",
                Model = "M6",
                NumberOfSeats = 5,
                Photo = "https://d62-a.sdn.cz/d_62/c_img_QK_N/pN5b/Hyan-Zaz-Zaporozec.jpeg?fl=cro,0,118,2362,1328%7Cres,1200,,1%7Cwebp,75",
                Type = Enums.CarType.Saloon
            };

            await SUT.GetRepository<CarEntity>().InsertOrUpdateAsync<CarDetailModel>(model, Mapper);
            await SUT.CommitAsync();

            var entity = SUT.GetRepository<CarEntity>().Get().SingleOrDefault(x => x.Model == model.Model);
            Assert.NotNull(entity);
        }


        [Fact]
        public async Task RideInsertRepository()
        {
            var model = new RideDetailModel
            {
                ID = Guid.Parse("{FA4FF1E9-D72F-4859-8F4B-1FD3EF56046F}"),
                EndLocation = "Rome",
                StartLocation = "Naples",
                TimeOfArrival = new DateTime(2021,12,01,15,40,00),
                TimeOfDeparture = new DateTime(2021,12,01,08,19,00)
            };

            await SUT.GetRepository<RideEntity>().InsertOrUpdateAsync<RideDetailModel>(model, Mapper);
            await SUT.CommitAsync();

            var entity = SUT.GetRepository<RideEntity>().Get().SingleOrDefault(x => x.TimeOfArrival == model.TimeOfArrival);
            Assert.NotNull(entity);
        }

        [Fact]
        public async Task UserInsertRepository()
        {
            var model = new UserDetailModel
            {
                ID = Guid.Parse("{D6774EFE-28EA-4796-B0C1-FDE3F534D9D4}"),
                Name = "Denis",
                Surname = "Bakham",
                Photo = "abrakadabra.jpg"
            };

            await SUT.GetRepository<UserEntity>().InsertOrUpdateAsync<UserDetailModel>(model, Mapper);
            await SUT.CommitAsync();

            var entity = SUT.GetRepository<UserEntity>().Get().SingleOrDefault(x => x.Surname == model.Surname && x.Name == model.Name);
            Assert.NotNull(entity);
        }
    }
}