using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    /// <summary>
    /// Create order command handler.
    /// </summary>
    /// <seealso cref="IRequestHandler&lt;CreateOrderCommand, Order;" />
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        /// <summary>
        /// The order repository
        /// </summary>
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrderCommandHandler"/> class.
        /// </summary>
        /// <param name="orderRepository">The order repository.</param>
        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var seatClass = string.Empty;

                if (Regex.IsMatch(request.SeatClass, "Economy|economy"))
                    seatClass = "Economy class";
                else if(Regex.IsMatch(request.SeatClass, "Business|business"))
                    seatClass = "Business class";
                var order = _orderRepository.Add(new Order(request.FlightNumber, request.PassengerName, request.Quantity, seatClass));
                await _orderRepository.UnitOfWork.SaveEntitiesAsync();
                return order;
            }
            return null;
        }
    }
}
