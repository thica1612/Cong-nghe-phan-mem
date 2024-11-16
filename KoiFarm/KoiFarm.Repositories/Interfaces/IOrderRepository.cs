using KoiFarm.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarm.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(KoiOrder order);
        Task<bool> DelOrder(int orderId);
        Task<bool> DelOrder(KoiOrder order);
        Task<KoiOrder> GetOrderById(int orderId);
        Task<List<KoiOrder>> GetAllOrders();
        Task<bool> UpdateOrder(KoiOrder order);

        Task AddToOrderAsync(Guid customerId, string koiId, int quantity);
        Task<KoiOrder?> GetCurrentOrderAsync(Guid customerId);
        Task<KoiOrder?> GetOrderByIdAsync(int orderId);
    }
}
