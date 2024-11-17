using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KoiFarm.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly KoiFarmContext _context;

        public OrderDetailRepository(KoiFarmContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetail == null) return false; 
            await _context.OrderDetails.AddAsync(orderDetail);
            return await Save();
        }

        public async Task<bool> DeleteOrderDetail(int orderDetailId)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(orderDetailId);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                return await Save();
            }
            return false;
        }

        public Task<bool> DeleteOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DelOrderDetail(int orderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DelOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDetail>> GetAllOrderByUser(int orderId)
        {
            var orderDetails = await _context.KoiOrders
                    .Where(order => order.OrderId == orderId && order.Status != "Completed")
                        .SelectMany(order => order.OrderDetails)
                            .Include(detail => detail.Koi)
                                .ToListAsync();

            return orderDetails;
        }

        public async Task<List<OrderDetail>> GetAllOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(int orderDetailId)
        {
            return await _context.OrderDetails.FindAsync(orderDetailId);
        }

        public async Task<bool> UpdateOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetail == null) return false; 
            _context.OrderDetails.Update(orderDetail);
            return await Save();
        }

        private async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
