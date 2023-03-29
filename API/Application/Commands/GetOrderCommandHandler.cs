using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class GetOrderCommandHandler : IRequestHandler<GetOrderCommand, Order>
    {
        /// <summary>
        /// The flight repository
        /// </summary>
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderCommandHandler"/> class.
        /// </summary>
        /// <param name="orderRepository">The order repository.</param>
        public GetOrderCommandHandler(IOrderRepository orderRepository)
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
        public async Task<Order> Handle(GetOrderCommand request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAsync(request.Id);
            return orders;
        }
    }
}
