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
    public class AirportsController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<AirportsController> _logger;

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirportsController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="mediator">The mediator.</param>
        /// <param name="mapper">The mapper.</param>
        public AirportsController(
            ILogger<AirportsController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Stores the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The airport save status.</returns>
        [HttpPost]
        public async Task<IActionResult> Store([FromBody]CreateAirportCommand command)
        {
            var airport = await _mediator.Send(command);
            return Ok(_mapper.Map<AirportViewModel>(airport));
        }
    }
}