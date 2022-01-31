namespace BitsCraft.Starter.Domain.WeatherContext
{
    public class WeatherException : Exception
    {
        public WeatherException()
        { }

        public WeatherException(string message)
            : base(message)
        { }

        public WeatherException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
