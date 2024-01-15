using TMS_API.Models.DTO;
using TMS_API.Models;
using AutoMapper;


namespace TMS_API.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrdersPatchDTO>().ReverseMap();
            //CreateMap<Order, OrdersDTO>()
            //.ForMember(dest => dest.TicketsCategory, opt => opt.MapFrom(src => src.TicketCategory))
            //.ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.EventName));
            CreateMap<Order, OrdersDTO>()
            //.ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.Event))
            .ForMember(dest => dest.TicketsCategory, opt => opt.MapFrom(src => src.TicketCategory))
            .ReverseMap();

            //CreateMap<Order, OrdersDTO>()
            //    .ForMember(dest => dest.TicketsCategory, opt => opt.MapFrom(src => src.TicketCategory))  // Map TicketCategory entity to TicketCategoryDTO
            //    .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.EventName))
            //    .ReverseMap();
        }
    }
}
