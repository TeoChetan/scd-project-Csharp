using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TMS_API.Models;
using TMS_API.Models.DTO;
using TMS_API.Repositories;
using AutoMapper;
//using TMS_API.Exceptions;

namespace TMS_API.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EventController(IEventRepository eventRepository,IMapper mapper,ILogger<EventController> logger) {

             _eventRepository = (EventRepository?)eventRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<EventDTO>> GetAll()
        {
            var events = _eventRepository.GetAllEvents();
            //var dtoEvents = new List<EventDTO>();
            //foreach (var @event in events)
            //{
            //    var eventDto = new EventDTO()
            //    {
            //        EventId = @event.EventId,
            //        EventDescription = @event.EventDescription,
            //        EventName = @event.EventName??string.Empty,
            //        EventType = @event.EventType?.EventTypeName??string.Empty,
            //        Venue = @event.Venue?.Location??string.Empty
            //    };
            //    dtoEvents.Add(eventDto);
            //}

            //var dtoEvents = events.Select(e => new EventDTO()
            //{
            //    EventId = e.EventId,
            //    EventDescription = e.EventDescription,
            //    EventName = e.EventName ?? string.Empty,
            //    EventType = e.EventType?.EventTypeName ?? string.Empty,
            //    Venue = e.Venue?.Location ?? string.Empty
            //});

            var dtoEvents = _mapper.Map<List<EventDTO>>(events);


            ////LINQ Method Query
            //var filterEvents = events.Where(e=>e.EventName == "Untold").FirstOrDefault();

            return Ok(dtoEvents);

        }

        [HttpGet]
        public async Task <ActionResult<EventDTO>> GetById(int Id)
        {
      
                var @event = await _eventRepository.GetById(Id);

                //var dtoEvent = new EventDTO()
                //{
                //    EventId = @event.EventId,
                //    EventDescription = @event.EventDescription,
                //    EventName = @event.EventName,
                //    EventType = @event.EventType?.EventTypeName ?? string.Empty,
                //    Venue = @event.Venue?.Location ?? string.Empty
                //};

                var eventDto = _mapper.Map<EventDTO>(@event);

                if (@event == null)
                {
                  NotFound();//throw new EntityNotFoundException(Id, nameof(Event));
                }

                return Ok(eventDto);
      
           
                    
            
        }

        [HttpPatch]
        public async Task <ActionResult<EventPatchDTO>> Patch(EventPatchDTO eventPatch)
        {
            var eventEntity = await _eventRepository.GetById((int)eventPatch.EventId);
            if(eventEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(eventPatch, eventEntity);
            _eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            var orderEntity = await _eventRepository.GetById(Id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _eventRepository.Delete(orderEntity);
            return NoContent();
        }

    }
}
