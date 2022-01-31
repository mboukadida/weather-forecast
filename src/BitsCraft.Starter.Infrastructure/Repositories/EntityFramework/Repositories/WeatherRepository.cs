using BitsCraft.Starter.Domain.SeedWork;
using BitsCraft.Starter.Domain.WeatherContext.WeatherAggregate;

namespace BitsCraft.Starter.Infrastructure.Repositories.EntityFramework.Repositories;

public class WeatherRepository : IWeatherRepository
{
    private readonly WeatherContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public WeatherRepository(WeatherContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public WeatherForecast GetById(int id)
    {
        throw new NotImplementedException();
    }

    public WeatherForecast Save(WeatherForecast weatherForecast)
    {
        throw new NotImplementedException();
    }
}