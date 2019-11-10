using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Models
{
    /// <summary>
    /// The Order 
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The Order id
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// The Order Status
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Total order amount
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Final payble amount after discount
        /// </summary>
        public decimal AmountPayable { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}
