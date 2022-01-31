namespace BitsCraft.Starter.Domain.SeedWork
{
    public interface IRepository<T>
    where T : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
