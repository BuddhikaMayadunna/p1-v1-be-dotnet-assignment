using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace API.Application.Commands
{
    /// <summary>
    /// Get flight command handler.
    /// </summary>
    /// <seealso cref="IRequestHandler&lt;GetFlightCommand, IEnumerable&lt;Flight&gt;&gt;" />
    public class GetFlightCommandHandler : IRequestHandler<GetFlightCommand,IEnumerable<Flight>>
    {
        /// <summary>
        /// The flight repository
        /// </summary>
        private readonly IFlightRepository _flightRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetFlightCommandHandler"/> class.
        /// </summary>
        /// <param name="flightRepository">The flight repository.</param>
        public GetFlightCommandHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<IEnumerable<Flight>> Handle(GetFlightCommand request, CancellationToken cancellationToken)
        {
            var airport = await _flightRepository.GetFlightsByDestinationAsync(request.DestinationAirportCode);
            return airport;
        }
    }
}
