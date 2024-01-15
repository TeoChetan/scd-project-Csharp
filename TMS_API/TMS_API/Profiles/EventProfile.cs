using AutoMapper;
using TMS_API.Models;
using TMS_API.Models.DTO;

namespace TMS_API.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<TicketsCategory, TicketsCategoryDTO>().ReverseMap();
            CreateMap<Event, EventPatchDTO>().ReverseMap();
            CreateMap<Event, EventDTO>()
            .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue.Location))
            .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType.EventTypeName))
            .ForMember(dest => dest.TicketsCategory, opt => opt.MapFrom(src => src.TicketsCategories))
            .ReverseMap();


        }
    }
}
