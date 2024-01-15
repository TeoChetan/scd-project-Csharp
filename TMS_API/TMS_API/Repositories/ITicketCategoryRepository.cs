using TMS_API.Models;

namespace TMS_API.Repositories
{
    public interface ITicketCategoryRepository
    {
        Task<TicketsCategory> GetTicketById(int ticketId);

    }
}
