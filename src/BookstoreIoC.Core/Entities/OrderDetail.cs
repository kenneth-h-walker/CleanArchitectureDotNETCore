using System;
using System.Collections.Generic;

namespace BookstoreIoC.Core.Entities
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}
