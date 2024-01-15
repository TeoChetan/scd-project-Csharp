using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMS_API.Models.DTO;
using TMS_API.Repositories;

namespace TMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;


        public OrderController(IOrdersRepository orderRepository, IMapper mapper, ITicketCategoryRepository ticketCategoryRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _ticketCategoryRepository = ticketCategoryRepository;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<OrdersDTO>> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();

            //var dtoOrders = orders.Select(e => new OrdersDTO()
            //{
            //    OrdersId = e.OrdersId,
            //    NumberOfTickets = (int)e.NumberOfTickets,
            //    TotalPrice = (double)e.TotalPrice,
            //    OrderedAt = (DateTime)e.OrderedAt
            //}).ToList();
          //  var dtoOrders = _mapper.Map<List<OrdersDTO>>(orders.ToList());

            var dtoOrders = _mapper.Map<List<OrdersDTO>>(orders.ToList());

            return Ok(dtoOrders);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<OrdersDTO>> GetOrdersById(int Id)
        {
            var order = await _orderRepository.GetById(Id);

            if (order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrdersDTO>(order);

            return Ok(orderDto);
        }

        [HttpPatch]
        public async Task<ActionResult<OrdersPatchDTO>> Patch(OrdersPatchDTO orderPatch)
        {

            var orderEntity = await _orderRepository.GetById(id: orderPatch.OrdersId);
            if (orderEntity == null)
            {
                return NotFound();
            }
            if (orderPatch.TicketCategoryId != 0)
            {
                orderEntity.TicketCategoryId = orderPatch.TicketCategoryId;
                var ticketEntity = await _ticketCategoryRepository.GetTicketById((int)orderEntity.TicketCategoryId);
                orderEntity.TotalPrice = orderPatch.NumberOfTickets * ticketEntity.Price;

            }
            if (orderPatch.NumberOfTickets != 0)
            {
                orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;
            }
            _orderRepository.Update(orderEntity);
            return Ok(orderEntity);
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            var orderEntity = await _orderRepository.GetById(Id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(orderEntity);
            return NoContent();
        }



    }
}


