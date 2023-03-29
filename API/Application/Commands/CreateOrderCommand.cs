using Domain.Aggregates.OrderAggregate;
using Domain.Common;
using MediatR;
using System;

namespace API.Application.Commands
{
    /// <summary>
    /// Create order command.
    /// </summary>
    /// <seealso cref="IRequest;Order" />
    public class CreateOrderCommand : IRequest<Order>
    {
        /// <summary>
        /// Gets the flight number.
        /// </summary>
        /// <value>
        /// The flight number.
        /// </value>
        public Guid FlightNumber { get; private set; }

        /// <summary>
        /// Gets the name of the passenger.
        /// </summary>
        /// <value>
        /// The name of the passenger.
        /// </value>
        public string PassengerName { get; private set; }

        /// <summary>
        /// Gets the seat class.
        /// </summary>
        /// <value>
        /// The seat class.
        /// </value>
        public string SeatClass { get; private set; }

        /// <summary>
        /// Gets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrderCommand"/> class.
        /// </summary>
        /// <param name="flightNumber">The flight number.</param>
        /// <param name="passengerName">Name of the passenger.</param>
        /// <param name="seatClass">The seat class.</param>
        /// <param name="quantity">The quantity.</param>
        public CreateOrderCommand(Guid flightNumber, 
            string passengerName,
            string seatClass,
            int quantity)
        {
            FlightNumber = flightNumber;
            PassengerName = passengerName;
            SeatClass = seatClass;
            Quantity = quantity;
        }
    }
}
