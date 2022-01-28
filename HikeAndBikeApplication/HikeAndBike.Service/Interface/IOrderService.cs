using HikeAndBike.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikeAndBike.Service.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order getOrderDetails(BaseEntity model);
    }
}
