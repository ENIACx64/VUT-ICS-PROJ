namespace DB.Entities
{
    public interface IEntity<T>
    {
        T ID { get; }
    }
}