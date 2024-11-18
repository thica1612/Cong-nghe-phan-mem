using KoiFarm.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetail>> GetAllOrderDetails();
        Task<OrderDetail> GetOrderDetailById(int orderDetailId);
        Task<bool> AddOrderDetail(OrderDetail orderDetail);
        Boolean UpdateOrderDetail(OrderDetail orderDetail);
        Task<bool> DeleteOrderDetail(int orderDetailId);
        Task<bool> DeleteOrderDetail(OrderDetail orderDetail);
        Boolean DelOrderDetail(int orderDetailId);
        Task<bool> DelOrderDetail(OrderDetail orderDetail);

        Task<List<OrderDetail>> GetAllOrderByUser(int orderId);
    }
}
