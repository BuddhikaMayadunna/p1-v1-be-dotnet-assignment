using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;

namespace API.Application.Commands
{
    /// <summary>
    /// Get order command.
    /// </summary>
    /// <seealso cref="IRequest;IEnumerable;Order" />
    public class GetOrderCommand : IRequest<Order>
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderCommand"/> class.
        /// </summary>
        public GetOrderCommand( Guid id) {
            Id = id;
        }    
    }
}
