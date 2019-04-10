using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookstoreIoC.Core.Entities;
using BookstoreIoC.Core.Interfaces;

namespace BookstoreIoC.WebUI.Pages.Authors
{
    public class EditModel : PageModel
    {
        private readonly IAuthorRepository _repository;

        public EditModel(IAuthorRepository repository)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _repository.UpdateAsync(Author);
            }
            catch (Exception)
            {
                if (!AuthorExists(Author.AuthorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AuthorExists(int id)
        {
            return (_repository.GetById(id) != null);
        }
    }
}
