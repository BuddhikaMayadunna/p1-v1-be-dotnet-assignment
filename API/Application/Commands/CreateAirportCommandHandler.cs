using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.AirportAggregate;
using MediatR;

namespace API.Application.Commands
{
    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, Airport>
    {
        /// <summary>
        /// The airport repository
        /// </summary>
        private readonly IAirportRepository _airportRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAirportCommandHandler"/> class.
        /// </summary>
        /// <param name="airportRepository">The airport repository.</param>
        public CreateAirportCommandHandler(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<Airport> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = _airportRepository.Add(new Airport(request.Code, request.Name));
            await _airportRepository.UnitOfWork.SaveEntitiesAsync();
            return airport;
        }
    }
}