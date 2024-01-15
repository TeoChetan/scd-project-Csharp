//using Microsoft.EntityFrameworkCore;
//using TMS_API.Models;

//namespace TMS_API.Repositories
//{
//    public class EventTypeRepository : IEventTypeRepository
//    {

//        private readonly TicketManagementSystemContext _dbContext;
//        public EventTypeRepository()
//        {

//            _dbContext = new TicketManagementSystemContext();
//        }
//        public Task<EventsType> AddAsync(EventsType entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Task DeleteAsync(EventsType entity)
//        {
//            throw new NotImplementedException();
//        }

//        public DbSet<EventsType> GetAll()
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IReadOnlyList<EventsType>> GetAllAsync()
//        {
//            var events = _dbContext.EventsTypes;
//            return (IReadOnlyList<EventsType>)events;
//        }

//        public Task<EventsType> GetByIdAsync(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task UpdateAsync(EventsType entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
