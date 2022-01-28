using HikeAndBike.Domain.Domain;
using HikeAndBike.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikeAndBike.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public AdminController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return this._orderService.GetAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {
            return this._orderService.getOrderDetails(model);
        }
    }
}
