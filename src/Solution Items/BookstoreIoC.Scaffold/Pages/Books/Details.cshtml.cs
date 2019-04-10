using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookstoreIoC.Core.Entities;
using BookstoreIoC.Scaffold.Models;

namespace BookstoreIoC.Scaffold.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly BookstoreIoC.Scaffold.Models.BookstoreContext _context;

        public DetailsModel(BookstoreIoC.Scaffold.Models.BookstoreContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books
                .Include(b => b.Author).FirstOrDefaultAsync(m => m.BookId == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
