using System;

namespace API.Application.ViewModels
{
    public class OrderViewModel
    {
        /// <summary>
        /// Gets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public Guid OrderId { get;  set; }

        /// <summary>
        /// Gets the flight number.
        /// </summary>
        /// <value>
        /// The flight number.
        /// </value>
        public Guid FlightNumber { get;  set; }

        /// <summary>
        /// Gets the name of the passenger.
        /// </summary>
        /// <value>
        /// The name of the passenger.
        /// </value>
        public string PassengerName { get;  set; }

        /// <summary>
        /// Gets the seat class.
        /// </summary>
        /// <value>
        /// The seat class.
        /// </value>
        public string SeatClass { get;  set; }

        /// <summary>
        /// Gets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get;  set; }

        /// <summary>
        /// Gets a value indicating whether this instance is confirmed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is confirmed; otherwise, <c>false</c>.
        /// </value>
        public bool IsConfirmed { get;  set; }
    }
}
