using BitsCraft.Starter.Domain.SeedWork;

namespace BitsCraft.Starter.Domain.WeatherContext.WeatherAggregate;

public class Temperature : ValueObject
{
    public int Value { get; private set; }

    public Degree Degree { get; private set; }

    public Temperature(int value, Degree degree)
    {
        Value = value;
        Degree = degree;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Degree;
    }
}