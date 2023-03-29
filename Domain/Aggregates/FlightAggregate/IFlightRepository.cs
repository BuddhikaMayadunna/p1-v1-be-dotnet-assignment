using Domain.Aggregates.AirportAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate
{
    /// <summary>
    /// The flight repository interface.
    /// </summary>
    /// <seealso cref="IRepository&lt;Flight&gt;" />
    public interface IFlightRepository: IRepository<Flight>
    {
        /// <summary>
        /// Gets the flights by destination asynchronous.
        /// </summary>
        /// <param name="destinationCode">The destination code.</param>
        /// <returns>The flight list.</returns>
        Task<IEnumerable<Flight>> GetFlightsByDestinationAsync(string destinationCode);
    }
}