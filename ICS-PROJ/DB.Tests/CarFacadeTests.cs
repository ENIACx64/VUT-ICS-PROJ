using BL.Facades;
using BL.Models;
using DB.Tests.Seeds;
using DB.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DB.Tests;
public class CarFacadeTests : Bases.BaseMapperTests<CarFacade>
{
    public CarFacadeTests()
    {
        var unitOfWorkFactory = new UnitOfWorkFactory(DbFactory);
        SUT = new CarFacade(unitOfWorkFactory, Mapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var _ = await SUT.SaveAsync(ModelSeeds.CarDetailModel);
    }

    [Fact]
    public async Task GetAll_Single_SeededMiniCooper()
    {
        var cars = await SUT.GetAsync();
        var car = cars.Single(i => i.ID == CarSeeds.MiniCooper.ID);

        DeepAssert.Equal(Mapper.Map<CarListModel>(CarSeeds.MiniCooper), car);
    }

    [Fact]
    public async Task GetById_SeededMiniCooper()
    {
        var car = await SUT.GetAsync(CarSeeds.MiniCooper.ID);

        DeepAssert.Equal(Mapper.Map<CarDetailModel>(CarSeeds.MiniCooper), car);
    }


    [Fact]
    public async Task GetById_NonExistent()
    {
        var ingredient = await SUT.GetAsync(CarSeeds.EmptyCar.ID);

        Assert.Null(ingredient);
    }

}

