using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public string SKU { get; set; }

        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }

    }
}
