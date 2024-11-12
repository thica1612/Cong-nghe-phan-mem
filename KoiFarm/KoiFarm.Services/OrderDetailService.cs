using KoiFarm.Repositories;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KoiFarm.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _repository;

        public OrderDetailService(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddOrderDetail(OrderDetail orderDetail)
        {
            return await _repository.AddOrderDetail(orderDetail);
        }

        public async Task<bool> DelOrderDetail(int orderDetailId)
        {
            return await _repository.DelOrderDetail(orderDetailId);
        }

        public async Task<bool> DelOrderDetail(OrderDetail orderDetail)
        {
            return await _repository.DelOrderDetail(orderDetail);
        }

        public async Task<OrderDetail> GetOrderDetailById(int orderDetailId)
        {
            return await _repository.GetOrderDetailById(orderDetailId);
        }

        public async Task<List<OrderDetail>> GetAllOrderDetails()
        {
            return await _repository.GetAllOrderDetails();
        }

        public async Task<bool> UpdateOrderDetail(OrderDetail orderDetail)
        {
            return await _repository.UpdateOrderDetail(orderDetail);
        }
    }
}
