using HikeAndBike.Domain.Domain;
using HikeAndBike.Repository.Interface;
using HikeAndBike.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository){
            _orderRepository = orderRepository;
        }
        public List<Order> GetAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return this._orderRepository.getOrderDetails(model);
        }
    }
}
