using KoiFarm.Repositories;
using KoiFarm.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarm.Services.Interfaces
{
    public interface IOrderService
    {
        Task<bool> AddOrder(KoiOrder order);
        Task<bool> DelOrder(int orderId);
        Task<bool> DelOrder(KoiOrder order);
        Task<KoiOrder> GetOrderById(int orderId);
        Task<List<KoiOrder>> GetAllOrders();
        Task<bool> UpdateOrder(KoiOrder order);
    }
}
