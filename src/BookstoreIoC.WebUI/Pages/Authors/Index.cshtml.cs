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
    public class IndexModel : PageModel
    {
        private readonly IAuthorRepository _repository;

        public IndexModel(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public IList<Author> Author { get;set; }

        public async Task OnGetAsync()
        {
            Author = await _repository.ListAllAsync();
        }
    }
}
