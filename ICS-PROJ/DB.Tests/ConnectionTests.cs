using DB.Contexts;
using DB.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using DB.UnitOfWork;
using DB.Entities;
using System.Threading.Tasks;
using BL.Models;
using System;
using AutoMapper;
using AutoMapper.EquivalencyExpression;

namespace DB.Tests
{
    public class UnitOfWorkTests : BaseTest<IUnitOfWork>
    {
        private readonly IMapper mapper;

        public UnitOfWorkTests()
        {
            var dBContextOptions = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseInMemoryDatabase(nameof(ProjectDbContextTests));

            var context = new TestDbContext(dBContextOptions.Options);
            context.RideEntities.Add(RideSeeds.Ride1);
            context.CarEntities.Add(CarSeeds.MiniCooper);
            context.UserEntities.Add(UserSeeds.User1);
            context.SaveChanges();

            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(IModel<Guid>));
                cfg.AddCollectionMappers();
                cfg.UseEntityFrameworkCoreModel<ProjectDbContext>(context.Model);
            }));

            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            SUT = new DB.UnitOfWork.UnitOfWork(context);
        }

        [Fact]
        public async Task GetRepository()
        {
            var entity = SUT.GetRepository<UserEntity>().Get().SingleOrDefault(x => x.ID == UserSeeds.User1.ID);
            Assert.NotNull(entity);
            Assert.Equal(UserSeeds.User1.ID, entity.ID);

            SUT.GetRepository<UserEntity>().Delete(UserSeeds.User1.ID);
            await SUT.CommitAsync();

            Assert.False(SUT.GetRepository<UserEntity>().Get().Any(x => x.ID == UserSeeds.User1.ID));
        }

        [Fact]
        public async Task InsertRepository()
        {
            var carmodel = new CarDetailModel
            {
                ID = Guid.Parse("{DE7A8123-2624-402C-BB68-30BEFECE0291}"),
                DateOfRegistration = new DateTime(2021, 08, 13),
                Manufacturer = "Zaporozec",
                Model = "M6",
                NumberOfSeats = 5,
                Photo = "https://d62-a.sdn.cz/d_62/c_img_QK_N/pN5b/Hyan-Zaz-Zaporozec.jpeg?fl=cro,0,118,2362,1328%7Cres,1200,,1%7Cwebp,75",
                Type = Enums.CarType.Saloon
            };

            await SUT.GetRepository<CarEntity>().InsertOrUpdateAsync<CarDetailModel>(carmodel, mapper);
            await SUT.CommitAsync();

            var entity = SUT.GetRepository<CarEntity>().Get().SingleOrDefault(x => x.Model == carmodel.Model);
            Assert.NotNull(entity);
        }
    }
}