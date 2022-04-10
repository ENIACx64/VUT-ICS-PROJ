namespace DB.UnitOfWork;

public interface IUnitOfWorkFactory
{
    IUnitOfWork Create();
}