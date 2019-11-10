using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.API.Models;

namespace Sample.API.Services
{
    public interface IOrderService
    {
        List<Order> GetOrder();
        Order GetOrder(int id);
    }
}
