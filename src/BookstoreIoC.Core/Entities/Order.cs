using System;
using System.Collections.Generic;

namespace BookstoreIoC.Core.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
