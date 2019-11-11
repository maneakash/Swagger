using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.API.Models;
using Sample.API.Services;

namespace Sample.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "OrderOpenApiSpecification")]
    [ApiVersion("2.0")]
    public class OrderV2Controller : ControllerBase
    {
        readonly IOrderService _orderService;

        public OrderV2Controller(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>List of orders</returns>
        [HttpGet]
        public List<Order> Get()
        {
            return _orderService.GetOrder();
        }

    }
}