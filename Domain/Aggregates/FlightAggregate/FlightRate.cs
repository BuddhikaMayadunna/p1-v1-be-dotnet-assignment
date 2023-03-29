using Domain.Common;
using Domain.SeedWork;

namespace Domain.Aggregates.FlightAggregate
{
    public class FlightRate : Entity
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the price.
        /// </summary>
        public Price Price { get; private set; }

        /// <summary>
        /// Gets the available.
        /// </summary>
        public int Available { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightRate"/> class.
        /// </summary>
        protected FlightRate()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightRate"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="price">The price.</param>
        /// <param name="available">The available.</param>
        public FlightRate(string name, Price price, int available)
        {
            Name = name;
            Price = price;
            Available = available;
        }

        /// <summary>
        /// Changes the price.
        /// </summary>
        /// <param name="price">The price.</param>
        public void ChangePrice(Price price)
        {
            Price = price;
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns>The price in decimal value.</returns>
        public decimal GetPrice(Price price)
        {
            return price.Value;
        }

        /// <summary>
        /// Mutates the availability.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        public void MutateAvailability(int quantity)
        {
            Available -= quantity;
        }
    }
}