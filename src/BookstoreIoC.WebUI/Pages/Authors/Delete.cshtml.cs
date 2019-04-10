using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookstoreIoC.Core.Entities;
using BookstoreIoC.Core.Interfaces;

namespace BookstoreIoC.WebUI.Pages.Authors
{
    public class DeleteModel : PageModel
    {
        private readonly IAuthorRepository _repository;

        public DeleteModel(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _repository.GetByIdAsync(id.Value);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _repository.GetByIdAsync(id.Value);

            if (Author != null)
            {
                await _repository.DeleteAsync(Author);
            }

            return RedirectToPage("./Index");
        }
    }
}
