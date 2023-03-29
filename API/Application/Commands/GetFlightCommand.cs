using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Commands
{
    /// <summary>
    /// Get the flight command.
    /// </summary>
    /// <seealso cref="MediatR.IRequest&lt;System.Collections.Generic.IEnumerable&lt;Domain.Aggregates.FlightAggregate.Flight&gt;&gt;" />
    public class GetFlightCommand : IRequest<IEnumerable<Flight>>
    {
        /// <summary>
        /// Gets the destination airport code.
        /// </summary>
        /// <value>
        /// The destination airport code.
        /// </value>
        public string DestinationAirportCode { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetFlightCommand"/> class.
        /// </summary>
        /// <param name="destinationAirportCode">The destination airport code.</param>
        public GetFlightCommand(string destinationAirportCode)
        {
            this.DestinationAirportCode = destinationAirportCode;   
        }
    }
}
