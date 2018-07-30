namespace MyLibrary.App.Pages.Books
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.App.BasePageModels;
    using MyLibrary.App.Models;
    using MyLibrary.Data;

    public class StatusModel : BasePageModel
    {
        public StatusModel(MyLibraryContext context) 
            : base(context)
        {
        }
        [BindProperty]
        public string BookTitle { get; set; }

        [BindProperty]
        public ICollection<BookStatusViewModel> BookHistories { get; set; }

        public IActionResult OnGet(int id)
        {
            var book = this.Context.Books.Find(id);

            if (book == null)
            {
                return RedirectToPage("/Books/Details", new { id });
            }
            this.BookTitle = book.Title;

            this.BookHistories = this.Context.BorrowHistories
                 .Include(bh => bh.Borrower)
                 .Include(bh => bh.Book)
                 .Where(bh => bh.BookId == id)
                 .Select(bh => new BookStatusViewModel()
                 {
                     BorrowDate = bh.BorrowDate,
                     ReturnDate = bh.ReturnDate,
                     BorrowerName = bh.Borrower.Name
                 }).ToList();

            return Page();
        }
    }
}