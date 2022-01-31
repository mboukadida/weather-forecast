using BitsCraft.Starter.Domain.SeedWork;

namespace BitsCraft.Starter.Domain.WeatherContext.WeatherAggregate;

public interface IWeatherRepository : IRepository<WeatherForecast>
{
    WeatherForecast GetById(int id);
    WeatherForecast Save(WeatherForecast weatherForecast);
}