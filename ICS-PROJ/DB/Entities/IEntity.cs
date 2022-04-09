namespace DB.Entities
{
    internal interface IEntity<T>
    {
        T ID { get; }
    }
}