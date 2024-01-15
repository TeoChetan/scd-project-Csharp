//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.JsonPatch;
//using Microsoft.AspNetCore.Mvc;
//using TMS_API.Models.DTO;
//using TMS_API.Repositories;

//namespace TMS_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EventTypesController : ControllerBase
//    {
//        private readonly IEventRepository _eventRepository;
//        private readonly IEventTypeRepository _eventTypeRepository;
//        private readonly IMapper _mapper;

//        public EventTypesController(IEventRepository eventRepository, IEventTypeRepository eventTypeRepository, IMapper mapper)
//        {
//            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
//            _eventTypeRepository = eventTypeRepository ?? throw new ArgumentNullException(nameof(eventTypeRepository));
//            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
//        }

//        [HttpGet(Name = "GetAllEventsTypes")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesDefaultResponseType]
//        public async Task<ActionResult<IEnumerable<EventTypeDTO>>> GetEventsTypes()
//        {
//            var eventsTypes = await _eventTypeRepository.GetAllAsync();

//            return Ok(_mapper.Map<IEnumerable<EventTypeDTO>>(eventsTypes));
//        }

//        [HttpPatch("{id}", Name = "PartiallyUpdateEventType")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesDefaultResponseType]
//        public async Task<ActionResult<EventTypeDTO>> PartiallyUpdateEventType(
//            int id,
//            JsonPatchDocument<EventTypeDTO> eventTypePatch)
//        {
//            var eventTypeEntity = await _eventTypeRepository.GetByIdAsync(id);
//            if (eventTypeEntity == null)
//            {
//                return NotFound();
//            }

//            var eventTypeDto = _mapper.Map<EventTypeDTO>(eventTypeEntity);
//            eventTypePatch.ApplyTo(eventTypeDto);

//            if (!TryValidateModel(eventTypeDto))
//            {
//                return BadRequest(ModelState);
//            }
//            _mapper.Map(eventTypeDto, eventTypeEntity);

//            await _eventTypeRepository.UpdateAsync(eventTypeEntity);
//            return NoContent();
//        }

//        [HttpDelete("{id}", Name = "DeleteEventTypeById")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesDefaultResponseType]
//        public async Task<ActionResult> DeleteEventTypeById(int id)
//        {
//            var eventTypeDetails = await _eventTypeRepository.GetByIdAsync(id);

//            if (eventTypeDetails == null)
//            {
//                return NotFound();
//            }
//            await _eventTypeRepository.DeleteAsync(eventTypeDetails);
//            return NoContent();
//        }
//    }
//}
