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
    public class OrderRepository : IOrderRepository
    {
        private readonly KoiFarmContext _dbcontext;

        public OrderRepository(KoiFarmContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> AddOrder(KoiOrder order)
        {
            _dbcontext.Set<KoiOrder>().Add(order);
            return await _dbcontext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DelOrder(int orderId)
        {
            var order = await GetOrderById(orderId);
            if (order == null) return false;

            _dbcontext.Set<KoiOrder>().Remove(order);
            return await _dbcontext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DelOrder(KoiOrder order)
        {
            _dbcontext.Set<KoiOrder>().Remove(order);
            return await _dbcontext.SaveChangesAsync() > 0;
        }

        public async Task<KoiOrder> GetOrderById(int orderId)
        {
            return await _dbcontext.Set<KoiOrder>().FindAsync(orderId);
        }

        public async Task<List<KoiOrder>> GetAllOrders()
        {
            return await _dbcontext.Set<KoiOrder>().ToListAsync();
        }

        public async Task<bool> UpdateOrder(KoiOrder order)
        {
            _dbcontext.Set<KoiOrder>().Update(order);
            return await _dbcontext.SaveChangesAsync() > 0;
        }

        public async Task AddToOrderAsync(Guid customerId, string koiId, int quantity)
        {
            var currentOrder = await GetCurrentOrderAsync(customerId);

            if(currentOrder == null)
            {
                currentOrder = new KoiOrder()
                {
                    CustomerId = customerId,
                    OrderDate = DateOnly.FromDateTime(DateTime.Now),
                    Status = "In Progress",
                    TotalAmount = 0,
                };

                var koi = await _dbcontext.Kois.FindAsync(koiId);
                if(koi != null)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderId = currentOrder.OrderId,
                        KoiId = koiId,
                        Quantity = quantity,
                        UnitPrice = koi.KoiPrice,
                    };

                    currentOrder.OrderDetails.Add(orderDetail);
                    currentOrder.TotalAmount += koi.KoiPrice * quantity;

                    await _dbcontext.SaveChangesAsync();
                }
            }
        }

        public async Task<KoiOrder?> GetCurrentOrderAsync(Guid customerId)
        {
            return await _dbcontext.KoiOrders.Include(o=>o.OrderDetails)
                .FirstOrDefaultAsync(p => p.CustomerId == customerId && p.Status == "In Progress");
        }

        public async Task<KoiOrder?> GetOrderByIdAsync(int orderId)
        {
            return await _dbcontext.KoiOrders
                .Include(o=>o.OrderDetails)
                .FirstOrDefaultAsync(p=>p.OrderId == orderId);
        }
    }
}
