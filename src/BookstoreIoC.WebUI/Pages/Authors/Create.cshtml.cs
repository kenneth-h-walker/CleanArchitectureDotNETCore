using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookstoreIoC.Core.Entities;
using BookstoreIoC.Core.Interfaces;

namespace BookstoreIoC.WebUI.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly IAuthorRepository _repository;

        public CreateModel(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.AddAsync(Author);

            return RedirectToPage("./Index");
        }
    }
}