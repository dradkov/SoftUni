using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibrary.App.BasePageModels;
using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.App.Pages.Borrowers
{
    public class AddModel : BasePageModel
    {

        public AddModel(MyLibraryContext context)
            :base(context)
        {
        }

        [BindProperty]
        [Required]
        [MinLength(2)]
        [MaxLength(45)]
        public string Name { get; set; }

        [BindProperty]
        [Required]
        [MinLength(2)]
        [MaxLength(145)]
        public string Address { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public IActionResult OnPost()
        {
            var borrower = new Borrower()
            {
                Name = Name,
                Address = Address,
                Email = Email
            };

            this.Context.Borrowers.Add(borrower);
            this.Context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}