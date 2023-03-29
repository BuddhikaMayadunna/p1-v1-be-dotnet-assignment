using System.Collections.Generic;
using System.Threading.Tasks;
using API.Application.Commands;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<FlightsController> _logger;

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightsController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="mediator">The mediator.</param>
        /// <param name="mapper">The mapper.</param>
        public FlightsController(
            ILogger<FlightsController> logger,
                IMediator mediator,
                IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the available flights.
        /// </summary>
        /// <param name="airportCode">The airport code.</param>
        /// <returns>The available flight for the destination.</returns>
        [HttpGet]
        //[Route("Search")]
        public async Task<IActionResult> GetAvailableFlights(string airportCode)
        {
            var flights = await _mediator.Send(new GetFlightCommand(airportCode));
            return Ok(_mapper.Map<IEnumerable<FlightViewModel>>(flights));
        }
    }
}