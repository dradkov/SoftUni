using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLibrary.App.BasePageModels;
using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.App.Pages.Authors
{
    public class DetailsModel : BasePageModel
    { 

        public DetailsModel(MyLibraryContext context)
            :base(context)
        {
        }

        [BindProperty]
        public string AuthorName { get; set; }

        [BindProperty]
        public ICollection<Book> AuthorBooks { get; set; }

        public void OnGet(int id)
        {
            var author = this.Context.Authors
                .Include(a => a.Books)
                .First(a => a.Id == id);

            AuthorName = author.Name;
            AuthorBooks = author.Books;
        }
    }
}