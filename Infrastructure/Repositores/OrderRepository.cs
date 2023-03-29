using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastructure.Repositores
{
    /// <summary>
    /// The order repository.
    /// </summary>
    /// <seealso cref="Domain.Aggregates.OrderAggregate.IOrderRepository" />
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// The flight context.
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
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public OrderRepository(FlightsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>
        /// The order adding state.
        /// </returns>
        /// <exception cref="System.Exception">Invalid flight Id</exception>
        public  Order Add(Order order)
        {
            var validFlight = _context.Flights.Include(c=>c.Rates).FirstOrDefault(c=>c.Id ==order.FlightNumber);
            if (validFlight == null)
                throw new Exception("Invalid flight Id");

            var price = validFlight.Rates.FirstOrDefault(c=>c.Name == order.SeatClass).Price.Value;
            order.CalculateTotal(price);
            return _context.Orders.Add(order).Entity;
        }

        /// <summary>
        /// Confirms the specified order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>
        /// The order confirmation state.
        /// </returns>
        /// <exception cref="System.Exception">Invalid order Id</exception>
        public Order Confirm(Guid orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                throw new Exception("Order not found.");
            if (order.IsConfirmed)
                throw new Exception("Order already confirmed.");

            //Update flight availability
            var flight = _context.Flights.Include(c => c.Rates).FirstOrDefault(c => c.Id == order.FlightNumber);
            var rate = flight.Rates.FirstOrDefault(c => c.Name == order.SeatClass);
            flight.MutateRateAvailability(rate.Id, order.Quantity);        
            _context.FlightRates.Update(rate);

            order.ConfirmOrder();
            return _context.Orders.Update(order).Entity;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns>All the orders.</returns>
        public async Task<IEnumerable<Order>> GetAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        /// <summary>
        /// Gets the order by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The order by Id
        /// </returns>
        public async Task<Order> GetAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }
    }
}
