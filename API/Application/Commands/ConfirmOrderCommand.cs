using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    /// <summary>
    /// Confirm order command
    /// </summary>
    /// <seealso cref="IRequest;Order" />
    public class ConfirmOrderCommand : IRequest<Order>
    {
        /// <summary>
        /// Gets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmOrderCommand"/> class.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public ConfirmOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
