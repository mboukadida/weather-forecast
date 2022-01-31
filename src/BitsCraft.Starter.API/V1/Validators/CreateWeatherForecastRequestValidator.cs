using BitsCraft.Starter.API.V1.Requests;
using FluentValidation;

namespace BitsCraft.Starter.API.V1.Validators
{
    public class CreateWeatherForecastRequestValidator : AbstractValidator<RegisterWeatherForecastRequest>
    {
        public CreateWeatherForecastRequestValidator()
        {
            
        }
    }
}
