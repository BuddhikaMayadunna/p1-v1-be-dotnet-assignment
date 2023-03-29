using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    /// <summary>
    /// The flight repository.
    /// </summary>
    /// <seealso cref="IFlightRepository" />
    public class FlightRepository : IFlightRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly FlightsContext _context;

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public FlightRepository(FlightsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the flights by destination asynchronous.
        /// </summary>
        /// <param name="destinationCode">The destination code.</param>
        /// <returns>
        /// The flight list.
        /// </returns>
        /// <exception cref="System.Exception">Invalid desitnation</exception>
        public async Task<IEnumerable<Flight>> GetFlightsByDestinationAsync(string destinationCode)
        {
            var airport = await _context.Airports.FirstOrDefaultAsync(o => o.Code == destinationCode);
            if (airport == null)
                throw new Exception("Invalid desitnation");
            
            await _context.Flights.Include(c => c.Rates).ToListAsync();
            var res = await _context.Flights.Where(o => o.DestinationAirportId == airport.Id && o.Rates.Count > 0).ToListAsync();
            return res;
        }
    }
}
