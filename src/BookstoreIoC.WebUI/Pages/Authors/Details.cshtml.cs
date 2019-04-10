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
    public class DetailsModel : PageModel
    {
        private readonly IAuthorRepository _repository;

        public DetailsModel(IAuthorRepository repository)
        {
            _repository = repository;
        }

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
    }
}
