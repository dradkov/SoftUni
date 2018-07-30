namespace MyLibrary.App.Pages.Books
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.App.BasePageModels;
    using MyLibrary.Data;

    public class DetailsModel : BasePageModel
    {

        public DetailsModel(MyLibraryContext context)
            :base(context)
        {
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string AuthorName { get; set; }

        [BindProperty]
        public string Status { get; set; }

        [BindProperty]
        public string ImageUrl { get; set; }

        public void OnGet(int id)
        {
            var book = Context.Books
                .Include(b => b.Author)
                .First(b => b.Id == id);

            this.Id = book.Id;
            this.Title = book.Title;
            this.Description = book.Content;
            this.AuthorName = book.Author.Name;
            this.Status = book.Status;
            this.ImageUrl = book.ImageUrl;
        }

        public IActionResult OnGetReturn(int id)
        {
            var book = Context.Books.Include(b => b.History).FirstOrDefault(b => b.Id == id);
            book.History.Last().ReturnDate = DateTime.Now;
            book.Status = "At home";
            this.Context.SaveChanges();

            return RedirectToPage("/Books/Details", new { id });
        }
    }
}