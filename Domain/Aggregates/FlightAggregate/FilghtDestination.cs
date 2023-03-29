using Domain.SeedWork;
using System;

namespace Domain.Aggregates.FlightAggregate
{
    public class FilghtDestination : Entity, IAggregateRoot
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

        /// <summary>
        /// Initializes a new instance of the <see cref="FilghtDestination"/> class.
        /// </summary>
        /// <param name="departureAirportCode">The departure airport code.</param>
        /// <param name="arrivalAirportCode">The arrival airport code.</param>
        /// <param name="departure">The departure.</param>
        /// <param name="arrival">The arrival.</param>
        /// <param name="lowestPrice">The lowest price.</param>
        public FilghtDestination(string departureAirportCode,
            string arrivalAirportCode, 
            DateTimeOffset departure,
            DateTimeOffset arrival, 
            decimal lowestPrice)
        {
            DepartureAirportCode = departureAirportCode;
            ArrivalAirportCode = arrivalAirportCode;
            Departure = departure;
            Arrival = arrival;
            LowestPrice = lowestPrice;
        }
    }
}
