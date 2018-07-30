using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibrary.App.BasePageModels;
using MyLibrary.App.Models;
using MyLibrary.Data;

namespace MyLibrary.App.Pages
{
    public class IndexModel : BasePageModel
    {

        public IndexModel(MyLibraryContext context)
            :base(context)
        {
        }

        [BindProperty]
        public ICollection<IndexPageViewModel> BookModels { get; set; }

        public void OnGet()
        {
            this.BookModels = this.Context.Books
                .Select(IndexPageViewModel.FromBook())
                .ToList();
        }
    }
}
