namespace MyLibrary.App.Pages.Books
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using MyLibrary.App.BasePageModels;
    using MyLibrary.Data;
    using MyLibrary.Models;

    public class AddModel : BasePageModel
    {
        public AddModel(MyLibraryContext context)
            :base(context)
        {
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string AuthorName { get; set; }

        [BindProperty]
        public string ImageUrl { get; set; }

        public IActionResult OnPost()
       {
            var author = this.Context.Authors.FirstOrDefault(a => a.Name == AuthorName);

            if (author == null)
            {
                author = new Author()
                {
                    Name = AuthorName
                };

                this.Context.Authors.Add(author);
            }

            var book = new Book()
            {
                Title = Title,
                Author = author,
                Content = Description,
                ImageUrl = ImageUrl
            };

            this.Context.Books.Add(book);
            this.Context.SaveChanges();

            return this.RedirectToPage("/Books/Details", new { book.Id });

        }
    }
}