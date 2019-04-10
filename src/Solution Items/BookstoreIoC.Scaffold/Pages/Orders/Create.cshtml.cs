using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookstoreIoC.Core.Entities;
using BookstoreIoC.Scaffold.Models;

namespace BookstoreIoC.Scaffold.Pages.Orders
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
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}