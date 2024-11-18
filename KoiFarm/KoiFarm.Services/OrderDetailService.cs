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

        public Task<bool> AddOrderDetail(OrderDetail orderDetail)
        {
            return _repository.AddOrderDetail(orderDetail);
        }

        public Task<bool> DeleteOrderDetail(int orderDetailId)
        {
            return _repository.DeleteOrderDetail(orderDetailId);
        }

        public Task<bool> DeleteOrderDetail(OrderDetail orderDetail)
        {
            return _repository.DelOrderDetail(orderDetail);
        }

        public bool DelOrderDetail(int orderDetailId)
        {
            return _repository.DelOrderDetail(orderDetailId);
        }

        public Task<bool> DelOrderDetail(OrderDetail orderDetail)
        {
          return _repository.DelOrderDetail(orderDetail);
        }

        public Task<List<OrderDetail>> GetAllOrderByUser(int orderId)
        {
            return _repository.GetAllOrderByUser(orderId);
        }

        public Task<List<OrderDetail>> GetAllOrderDetails()
        {
            return _repository.GetAllOrderDetails();
            }

        public Task<OrderDetail> GetOrderDetailById(int orderDetailId)
        {
            return _repository.GetOrderDetailById(orderDetailId);
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
           return (_repository.UpdateOrderDetail(orderDetail));
        }
    }
}
