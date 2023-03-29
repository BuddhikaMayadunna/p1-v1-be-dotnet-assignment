using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using System.Linq;

namespace API.Mapping
{
    /// <summary>
    /// The Flight profile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class FlightProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightProfile"/> class.
        /// </summary>
        public FlightProfile()
        {
            CreateMap<Flight, FlightViewModel>()
                .ForMember(dest => dest.DepartureAirportCode, opt => opt.MapFrom(src => src.OriginAirportId))
                .ForMember(dest => dest.ArrivalAirportCode, opt => opt.MapFrom(src => src.DestinationAirportId))
                .ForMember(dest => dest.Arrival, opt => opt.MapFrom(src => src.Arrival))
                .ForMember(dest => dest.Departure, opt => opt.MapFrom(src => src.Departure))
                .ForMember(dest => dest.LowestPrice, opt => opt.MapFrom(src => src.Rates.Min(c=>c.GetPrice(c.Price))));
        }
    }
}
