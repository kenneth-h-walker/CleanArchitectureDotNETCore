using System;
using System.Collections.Generic;

namespace BookstoreIoC.Core.Entities
{
    public partial class Book
    {
        public Book()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool? IsActive { get; set; }

        public Author Author { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
