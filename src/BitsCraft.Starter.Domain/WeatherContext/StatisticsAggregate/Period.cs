using BitsCraft.Starter.Domain.SeedWork;

namespace BitsCraft.Starter.Domain.WeatherContext.StatisticsAggregate;

public class Period : ValueObject
{
    public int Month { get; private set; }
    public int Year { get; private set; }
    public double Value { get; private set; }

    public Period(int month, int year, double value)
    {
        Month = month;
        Year = year;
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Month;
        yield return Year;
    }
}