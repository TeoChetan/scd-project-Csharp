using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS_API.Models;

namespace TMS_API.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public OrdersRepository()
        {
             _dbContext = new TicketManagementSystemContext();
        }

        public void Delete(Order orders)
        {
            _dbContext.Remove(orders);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _dbContext.Orders
                .Include(e => e.TicketCategory);
                //.Include(e => e.Event);
                
            return orders;

        }

        public async Task<Order> GetById(int id)
        {

            var @event = _dbContext.Orders.Where(e => e.OrdersId == id).FirstOrDefault();
            return @event;
        }
       

        public void Update(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
