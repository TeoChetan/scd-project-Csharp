using TMS_API.Models;

namespace TMS_API.Repositories
{
    public interface IOrdersRepository
    {

        IEnumerable<Order> GetAllOrders();
        Task <Order> GetById(int id);
        void Update(Order order);
        void Delete(Order orders);
    }
}
