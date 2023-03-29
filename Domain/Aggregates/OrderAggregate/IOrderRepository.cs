using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        /// <summary>
        /// Adds the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>The order adding state.</returns>
        Order Add(Order order);

        /// <summary>
        /// Confirms the specified order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>The order confirmation state.</returns>
        Order Confirm(Guid orderId);

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>All orders.</returns>
        Task<IEnumerable<Order>> GetAsync();

        /// <summary>
        /// Gets the order by id.
        /// </summary>
        /// <returns>All orders.</returns>
        Task<Order> GetAsync(Guid id);
    }
}
