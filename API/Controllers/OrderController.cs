using API.Application.Commands;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<OrderController> _logger;

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="mediator">The mediator.</param>
        /// <param name="mapper">The mapper.</param>
        public OrderController(ILogger<OrderController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The order by Id.</returns>
        [HttpGet]
        public async Task<ActionResult<OrderViewModel>> GetOrder(Guid id)
        {
            var order = await _mediator.Send(new GetOrderCommand(id));
            return Ok(_mapper.Map<OrderViewModel>(order));
        }

        /// <summary>
        /// Orders the asynchronous.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The Order</returns>
        [HttpPost]
        public async Task<ActionResult<OrderViewModel>> Order([FromBody] CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);
            if (order == null)
                return NotFound();

            return CreatedAtAction(nameof(GetOrder), _mapper.Map<OrderViewModel>(order));
        }

        /// <summary>
        /// Orders the asynchronous.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The Order</returns>
        [HttpPatch]
        public async Task<IActionResult> ConfirmOrder([FromBody] ConfirmOrderCommand command)
        {
            var order = await _mediator.Send(command);
            if(order == null)
                return NotFound();

            return Ok(_mapper.Map<OrderViewModel>(order));
        }
    }
}
