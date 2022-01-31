using BitsCraft.Starter.Domain.SeedWork;
using BitsCraft.Starter.Domain.WeatherContext.SharedKernel;

namespace BitsCraft.Starter.Domain.WeatherContext.WeatherAggregate;

public class WeatherForecast : AggregateRoot
{
    public DateOnly Date { get; set; }

    public Temperature Temperature { get; set; }

    //public Temperature TemperatureF => new(32 + (int) (Temperature.Value / 0.5556), Degree.F);
    public string? Summary { get; set; }

    public Region Region { get; set; }
}