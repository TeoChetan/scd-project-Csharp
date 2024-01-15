using TMS_API.Models;

namespace TMS_API.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        Task <Event> GetById(int id);
        int Add(Event @event);
        void Update(Event @event);
        void Delete(Event @event);
    }
}
