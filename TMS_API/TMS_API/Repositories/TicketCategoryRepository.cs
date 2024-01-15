using Microsoft.EntityFrameworkCore;
using TMS_API.Models;

namespace TMS_API.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public TicketCategoryRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }
        public async Task<TicketsCategory> GetTicketById(int ticketId)
        {

            var ticketCategory = _dbContext.TicketsCategories.Where(tc => tc.TicketCategoryId==ticketId).FirstOrDefault();
            return ticketCategory;
           
        }
    }
}
