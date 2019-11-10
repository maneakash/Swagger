using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Models
{
    public enum OrderStatus
    {
        PENDING,
        AUTHORIZED,
        SHIPPED,
        CANCELLED,
        DELIVERED,
        RETURNED
    }
}
