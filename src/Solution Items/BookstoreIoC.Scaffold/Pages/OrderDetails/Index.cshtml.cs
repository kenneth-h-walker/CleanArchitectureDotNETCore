using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookstoreIoC.Core.Entities;
using BookstoreIoC.Scaffold.Models;

namespace BookstoreIoC.Scaffold.Pages.OrderDetails
{
    public class IndexModel : PageModel
    {
        private readonly BookstoreIoC.Scaffold.Models.BookstoreContext _context;

        public IndexModel(BookstoreIoC.Scaffold.Models.BookstoreContext context)
        {
            _context = context;
        }

        public IList<OrderDetail> OrderDetail { get;set; }

        public async Task OnGetAsync()
        {
            OrderDetail = await _context.OrderDetails
                .Include(o => o.Book)
                .Include(o => o.Order).ToListAsync();
        }
    }
}
