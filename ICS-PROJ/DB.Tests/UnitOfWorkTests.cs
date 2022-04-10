using BL.Models;
using DB.Entities;
using DB.Tests.Seeds;
using DB.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DB.Tests
{
    [Collection("UnitOfWorkTests collection")]
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
            var model = ModelSeeds.CarDetailModel;

            await SUT.GetRepository<CarEntity>().InsertOrUpdateAsync<CarDetailModel>(model, Mapper);
            await SUT.CommitAsync();

            var entity = SUT.GetRepository<CarEntity>().Get().SingleOrDefault(x => x.Model == model.Model);
            Assert.NotNull(entity);
        }


        [Fact]
        public async Task RideInsertRepository()
        {
            var model = ModelSeeds.RideDetailModel;

            await SUT.GetRepository<RideEntity>().InsertOrUpdateAsync<RideDetailModel>(model, Mapper);
            await SUT.CommitAsync();

            var entity = SUT.GetRepository<RideEntity>().Get().SingleOrDefault(x => x.TimeOfArrival == model.TimeOfArrival);
            Assert.NotNull(entity);
        }

        [Fact]
        public async Task UserInsertRepository()
        {
            var model = ModelSeeds.UserDetailModel;

            await SUT.GetRepository<UserEntity>().InsertOrUpdateAsync<UserDetailModel>(model, Mapper);
            await SUT.CommitAsync();

            var entity = SUT.GetRepository<UserEntity>().Get().SingleOrDefault(x => x.Surname == model.Surname && x.Name == model.Name);
            Assert.NotNull(entity);
        }
    }
}