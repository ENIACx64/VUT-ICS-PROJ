using BL.Facades;
using DB.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DB.Tests;
public class CarFacadeTests : Bases.BaseMapperTests<CarFacade>
{
    public CarFacadeTests()
    {
        var unitOfWorkFactory = new UnitOfWorkFactory((IDbContextFactory<DbContext>)DbFactory);
        SUT = new CarFacade(unitOfWorkFactory, Mapper);
    }
}

