using BitsCraft.Starter.Domain.SeedWork;
using BitsCraft.Starter.Domain.WeatherContext.StatisticsAggregate;

namespace BitsCraft.Starter.Infrastructure.Repositories.EntityFramework.Repositories;

public class StatisticsRepository : IStatisticsRepository
{
    public IUnitOfWork UnitOfWork { get; }
}