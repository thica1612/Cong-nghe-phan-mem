using KoiFarm.Repositories;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarm.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddOrder(KoiOrder order)
        {
            return await _repository.AddOrder(order);
        }

        public async Task<bool> DelOrder(int orderId)
        {
            return await _repository.DelOrder(orderId);
        }

        public async Task<bool> DelOrder(KoiOrder order)
        {
            return await _repository.DelOrder(order);
        }

        public async Task<KoiOrder> GetOrderById(int orderId)
        {
            return await _repository.GetOrderById(orderId);
        }

        public async Task<List<KoiOrder>> GetAllOrders()
        {
            return await _repository.GetAllOrders();
        }

        public async Task<bool> UpdateOrder(KoiOrder order)
        {
            return await _repository.UpdateOrder(order);
        }
    }
}
