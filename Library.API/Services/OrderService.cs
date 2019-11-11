using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.API.Models;

namespace Sample.API.Services
{
    class OrderService : IOrderService
    {
        readonly List<Order> Orders;


        public OrderService()
        {
            Orders = new List<Order>()
            {
                new Order()
                {
                    OrderId = 1,
                    Status = OrderStatus.AUTHORIZED,
                    UserId = new Guid().ToString(),
                    TotalAmount = 100,
                    AmountPayable = 90,
                    ShippingAddress = new Address()
                    {
                        Id = 1, FirstName = "ShipFName", LastName = "ShipLName", Country = "IN", State = "MH",
                        City = "Kolhapur", Zip = "416220"
                    },
                    BillingAddress = new Address()
                    {
                        Id = 1, FirstName = "BillFName", LastName = "BillLName", Country = "IN", State = "MH",
                        City = "Kolhapur", Zip = "416220"
                    },
                    OrderLines = new List<OrderLine>()
                        {new OrderLine() {OrderLineId = 1, SKU = "SKU-1", ProductPrice = 100, Quantity = 4}}
                }


            };
        }

        public List<Order> GetOrder()
        {
            return Orders;
        }

        public Order GetOrder(int id)
        {
            List<Order> orders = GetOrder();
            if (orders != null)
            {
                return Orders.Find(p => p.OrderId == id);
            }
            else
            {
                return null;
            }
        }
    }
}
