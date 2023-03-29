using System;

namespace API.Application.ViewModels
{
    /// <summary>
    /// The flight view model.
    /// </summary>
    public class FlightViewModel
    {
        /// <summary>
        /// Gets the departure airport code.
        /// </summary>
        /// <value>
        /// The departure airport code.
        /// </value>
        public string DepartureAirportCode { get; private set; }

        /// <summary>
        /// Gets the arrival airport code.
        /// </summary>
        /// <value>
        /// The arrival airport code.
        /// </value>
        public string ArrivalAirportCode { get; private set; }

        /// <summary>
        /// Gets the departure.
        /// </summary>
        /// <value>
        /// The departure.
        /// </value>
        public DateTimeOffset Departure { get; private set; }

        /// <summary>
        /// Gets the arrival.
        /// </summary>
        /// <value>
        /// The arrival.
        /// </value>
        public DateTimeOffset Arrival { get; private set; }

        /// <summary>
        /// Gets the lowest price.
        /// </summary>
        /// <value>
        /// The lowest price.
        /// </value>
        public decimal LowestPrice { get; private set; }
    }
}
