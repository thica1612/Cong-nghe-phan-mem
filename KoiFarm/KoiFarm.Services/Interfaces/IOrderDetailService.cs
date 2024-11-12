using KoiFarm.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarm.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task<bool> AddOrderDetail(OrderDetail orderDetail);
        Task<bool> DelOrderDetail(int orderDetailId);
        Task<bool> DelOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail> GetOrderDetailById(int orderDetailId);
        Task<List<OrderDetail>> GetAllOrderDetails();
        Task<bool> UpdateOrderDetail(OrderDetail orderDetail);

    }
}
