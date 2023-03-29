using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, Order>
    {
        /// <summary>
        /// The flight repository
        /// </summary>
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmOrderCommandHandler"/> class.
        /// </summary>
        /// <param name="orderRepository">The order repository.</param>
        public ConfirmOrderCommandHandler(IOrderRepository orderRepository)
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
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<Order> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.Confirm(request.OrderId);
            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            return order;
        }
    }
}
