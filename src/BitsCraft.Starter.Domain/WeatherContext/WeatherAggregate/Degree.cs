using BitsCraft.Starter.Domain.SeedWork;

namespace BitsCraft.Starter.Domain.WeatherContext.WeatherAggregate;

public class Degree : ValueObject
{
    public static readonly Degree C = new("C");
    public static readonly Degree F = new("F");
    public string Value { get; private set; }

    public Degree(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}