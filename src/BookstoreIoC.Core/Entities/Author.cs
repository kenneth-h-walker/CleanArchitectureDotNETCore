using System;
using System.Collections.Generic;

namespace BookstoreIoC.Core.Entities
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
