using AutoMapper;
using AutoMapper.EquivalencyExpression;
using BL.Models;
using DB.Contexts;
using System;

namespace DB.Tests.Bases;

public abstract class BaseMapperTests<T> : BaseDbContextTests<T>
{
    public IMapper Mapper { get; private set; }
    protected BaseMapperTests()
    {
        Mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(IModel<Guid>));
            cfg.AddCollectionMappers();
            cfg.UseEntityFrameworkCoreModel<ProjectDbContext>(DbFactory.CreateDbContext().Model);
        }));

        Mapper.ConfigurationProvider.AssertConfigurationIsValid();

    }
}

