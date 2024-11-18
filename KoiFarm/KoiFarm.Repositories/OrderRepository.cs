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
            var orderDetail = await _dbcontext.OrderDetails.FindAsync(orderId);
            if (orderDetail != null)
            {
                _dbcontext.OrderDetails.Remove(orderDetail);
                return true;
            }
            return false;
        }

        public async Task<bool> DelOrder(KoiOrder order)
        {
            try
            {
                _dbcontext.KoiOrders.Remove(order);
                _dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw new NotImplementedException(ex.ToString()); return false; }
        }

        public async Task<KoiOrder> GetOrderById(int orderId)
        {
            return await _dbcontext.Set<KoiOrder>().FindAsync(orderId);
        }

        public async Task<List<KoiOrder>> GetAllOrders()
        {
            return await _dbcontext.Set<KoiOrder>().ToListAsync();
        }

        public bool UpdateOrder(KoiOrder order)
        {
            try
            {
                _dbcontext.KoiOrders.Update(order);
                _dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task AddToOrderAsync(Guid customerId, string koiId, int quantity)
        {
            var currentOrder = await GetCurrentOrderAsync(customerId);
            var newOrderId = addOrderId();
            var newOrderDetailId = addOrderDetailId();
            if (currentOrder == null)
            {
                currentOrder = new KoiOrder()
                {
                    OrderId = newOrderId,
                    CustomerId = customerId,
                    OrderDate = DateOnly.FromDateTime(DateTime.Now),
                    Status = "In Progress",
                    TotalAmount = 0,
                    OrderDetails = new List<OrderDetail>()
                };
                await _dbcontext.KoiOrders.AddAsync(currentOrder);
                await _dbcontext.SaveChangesAsync();
            }

                var koi = await _dbcontext.Kois.FindAsync(koiId);
                if (koi == null)
                {
                    throw new Exception("Sản phẩm không tồn tại");
                }

                var existKoi = currentOrder.OrderDetails
                    .FirstOrDefault(p => p.KoiId == koiId);

                if (existKoi != null)
                {
                    existKoi.Quantity += quantity;
                }
                else
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderDetailId = newOrderDetailId,
                        OrderId = currentOrder.OrderId,
                        KoiId = koiId,
                        Quantity = quantity,
                        UnitPrice = koi.KoiPrice,
                    };
                    currentOrder.OrderDetails.Add(orderDetail);
                }

                currentOrder.TotalAmount = currentOrder.OrderDetails.Sum(p => p.Quantity * p.UnitPrice);
                await _dbcontext.SaveChangesAsync();
        }

        public int addOrderId()
        {
            var max = _dbcontext.KoiOrders.Max(o => o.OrderId);
            return max + 1;
        }
        public int addOrderDetailId()
        {
            var max = _dbcontext.OrderDetails.Max(o => o.OrderDetailId);
            return max + 1;
        }

        public async Task<KoiOrder?> GetCurrentOrderAsync(Guid customerId)
        {
            return await _dbcontext.KoiOrders.Include(o=>o.OrderDetails).ThenInclude(p => p.Koi)
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
