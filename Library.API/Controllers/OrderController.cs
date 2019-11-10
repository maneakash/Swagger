using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Sample.API.Models;
using Sample.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
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


        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <returns>Filtered order object</returns>
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderService.GetOrder(id);

        }

        /// <summary>
        /// Create new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns> HttpResponseMessage</returns>

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Order order)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}