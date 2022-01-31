using BitsCraft.Starter.Domain.SeedWork;
using BitsCraft.Starter.Domain.WeatherContext.SharedKernel;

namespace BitsCraft.Starter.Domain.WeatherContext.StatisticsAggregate
{
    public class Statistics : AggregateRoot
    {
        public Period Period { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public Region Region { get; set; }
        public Country Country { get; set; }
    }
}
