using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;

namespace API.Mapping
{
    /// <summary>
    /// Order map profile.
    /// </summary>
    /// <seealso cref="Profile" />
    public class OrderProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderProfile"/> class.
        /// </summary>
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}
