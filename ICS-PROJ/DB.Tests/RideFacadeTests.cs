using System.Linq;
using System.Threading.Tasks;
using Xunit;
using BL.Facades;
using BL.Models;
using DB.UnitOfWork;
using DB.Tests.Seeds;

namespace DB.Tests
{
    public class RideStartFacadeTests : Bases.BaseMapperTests<RideStartFacade>
    {
        public RideStartFacadeTests()
        {
            var UnitOfWorkFactory = new UnitOfWorkFactory(DbFactory);
            SUT = new RideStartFacade(UnitOfWorkFactory, Mapper);
        }

        [Fact]
        public async Task Create_WithNonExistingItem_DoesNotThrow()
        {
            var _ = await SUT.SaveAsync(ModelSeeds.RideDetailModel);
        }

        [Fact]
        public async Task GetAll_Single_Ride1()
        {
            var rides = await SUT.GetAsync();
            var ride = rides.Single(x => x.ID == RideSeeds.Ride1.ID);

            DeepAssert.Equal(Mapper.Map<RideStartListModel>(RideSeeds.Ride1), ride);
        }

        [Fact]
        public async Task GetById_Ride1()
        {
            var ride = await SUT.GetAsync(RideSeeds.Ride1.ID);

            DeepAssert.Equal(Mapper.Map<RideDetailModel>(RideSeeds.Ride1), ride);
        }
    }

    public class RideEndFacadeTests : Bases.BaseMapperTests<RideEndFacade>
    {
        public RideEndFacadeTests()
        {
            var UnitOfWorkFactory = new UnitOfWorkFactory(DbFactory);
            SUT = new RideEndFacade(UnitOfWorkFactory, Mapper);
        }

        [Fact]
        public async Task Create_WithNonExistingItem_DoesNotThrow()
        {
            var _ = await SUT.SaveAsync(ModelSeeds.RideDetailModel);
        }

        [Fact]
        public async Task GetAll_Single_Ride1()
        {
            var rides = await SUT.GetAsync();
            var ride = rides.Single(x => x.ID == RideSeeds.Ride1.ID);

            DeepAssert.Equal(Mapper.Map<RideEndListModel>(RideSeeds.Ride1), ride);
        }

        [Fact]
        public async Task GetById_Ride1()
        {
            var ride = await SUT.GetAsync(RideSeeds.Ride1.ID);

            DeepAssert.Equal(Mapper.Map<RideDetailModel>(RideSeeds.Ride1), ride);
        }
    }

    public class RideTimeFacadeTests : Bases.BaseMapperTests<RideTimeFacade>
    {
        public RideTimeFacadeTests()
        {
            var UnitOfWorkFactory = new UnitOfWorkFactory(DbFactory);
            SUT = new RideTimeFacade(UnitOfWorkFactory, Mapper);
        }

        [Fact]
        public async Task Create_WithNonExistingItem_DoesNotThrow()
        {
            var _ = await SUT.SaveAsync(ModelSeeds.RideDetailModel);
        }

        [Fact]
        public async Task GetAll_Single_Ride1()
        {
            var rides = await SUT.GetAsync();
            var ride = rides.Single(x => x.ID == RideSeeds.Ride1.ID);

            DeepAssert.Equal(Mapper.Map<RideTimeListModel>(RideSeeds.Ride1), ride);
        }

        [Fact]
        public async Task GetById_Ride1()
        {
            var ride = await SUT.GetAsync(RideSeeds.Ride1.ID);

            DeepAssert.Equal(Mapper.Map<RideDetailModel>(RideSeeds.Ride1), ride);
        }
    }
}
