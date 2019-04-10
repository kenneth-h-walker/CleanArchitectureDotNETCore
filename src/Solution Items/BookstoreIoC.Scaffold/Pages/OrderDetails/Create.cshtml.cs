using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookstoreIoC.Core.Entities;
using BookstoreIoC.Scaffold.Models;

namespace BookstoreIoC.Scaffold.Pages.OrderDetails
{
    public class CreateModel : PageModel
    {
        private readonly BookstoreIoC.Scaffold.Models.BookstoreContext _context;

        public CreateModel(BookstoreIoC.Scaffold.Models.BookstoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
        ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "Description");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}