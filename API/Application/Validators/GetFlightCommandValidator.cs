using API.Application.Commands;
using FluentValidation;

namespace API.Application.Validators
{
    /// <summary>
    /// Get flight command validator.
    /// </summary>
    /// <seealso cref="AbstractValidator&lt;GetFlightCommand&gt;" />
    public class GetFlightCommandValidator :AbstractValidator<GetFlightCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetFlightCommandValidator"/> class.
        /// </summary>
        public GetFlightCommandValidator()
        {
            RuleFor(c => c.DestinationAirportCode).NotEmpty().Length(3);
        }
    }
}
