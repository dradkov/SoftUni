using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLibrary.App.BasePageModels;
using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.App.Pages.Books
{
    public class BorrowModel : BasePageModel
    {

        public BorrowModel(MyLibraryContext context)
            :base(context)
        {
            this.BorrowDate = DateTime.Today;
        }

        [Required]
        [BindProperty]
        public string BookTitle { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Borrower Name")]
        public int BorrowerId { get; set; }

        [Required]
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [BindProperty]
        public List<SelectListItem> BorrowersNames { get; set; }

        public void OnGet(int id)
        {
            var book = this.Context.Books.Find(id);

            this.BookTitle = book.Title;
            this.BorrowersNames = this.Context.Borrowers
                .Select(b => new SelectListItem()
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                }).ToList();
        }

        public IActionResult OnPost(int id)
        {
          
           
            var book = this.Context.Books
                .Include(b => b.Borrowers)
                .FirstOrDefault(b => b.Id == id);
           

            var borrower = this.Context.Borrowers.FirstOrDefault(b => b.Id == this.BorrowerId);

            if (borrower == null)
            {
                return Page();
            }

            var bookBorrowers = new BorrowersBooks()
            {
                Book = book,
                Borrower = borrower
            };
            book.Borrowers.Add(bookBorrowers);
            borrower.BorrowedBooks.Add(bookBorrowers);

            var borrowHistory = new BorrowHistory()
            {
                Book = book,
                Borrower = borrower,
                BorrowDate = this.BorrowDate,
                ReturnDate = this.ReturnDate
            };
            this.Context.BorrowHistories.Add(borrowHistory);

            book.History.Add(borrowHistory);
            book.Status = "Borrowed";
            this.Context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}