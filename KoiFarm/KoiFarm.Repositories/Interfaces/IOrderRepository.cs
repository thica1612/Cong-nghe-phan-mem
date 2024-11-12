using KoiFarm.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarm.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(Order order);
        Task<bool> DelOrder(int orderId);
        Task<bool> DelOrder(Order order);
        Task<Order> GetOrderById(int orderId);
        Task<List<Order>> GetAllOrders();
        Task<bool> UpdateOrder(Order order);
    }
}
