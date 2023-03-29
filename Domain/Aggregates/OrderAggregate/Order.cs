using Domain.Common;
using Domain.Exceptions;
using Domain.SeedWork;
using System;

namespace Domain.Aggregates.OrderAggregate
{
    /// <summary>
    /// The order model.
    /// </summary>
    /// <seealso cref="Entity" />
    /// <seealso cref=IAggregateRoot" />
    public class Order : Entity, IAggregateRoot
    {
        /// <summary>
        /// Gets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public Guid OrderId { get; private set; }

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
        /// Gets a value indicating whether this instance is confirmed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is confirmed; otherwise, <c>false</c>.
        /// </value>
        public bool IsConfirmed { get; private set; }

        /// <summary>
        /// Gets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public decimal TotalPrice { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public Order(Guid orderId)
        {
            OrderId = orderId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="flightNumber">The flight number.</param>
        /// <param name="passengerName">Name of the passenger.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="seatClass">The seat class.</param>
        public Order(Guid flightNumber,
        string passengerName,
        int quantity, string seatClass) : this()
        {
            if (quantity < 1)
                throw new OrderDominException("Quantity must be grater than 0.");

            OrderId = Guid.NewGuid();
            FlightNumber = flightNumber;
            PassengerName = passengerName;
            Quantity = quantity;
            SeatClass = seatClass;
        }

        public void CalculateTotal(decimal rate)
        {
            TotalPrice = rate * Quantity;
        }
        /// <summary>
        /// Confirms the order.
        /// </summary>
        public void ConfirmOrder()
        {
            IsConfirmed = true;
        }
    }
}
