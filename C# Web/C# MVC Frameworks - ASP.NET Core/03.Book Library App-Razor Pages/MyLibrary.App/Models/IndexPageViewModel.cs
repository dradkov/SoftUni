using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyLibrary.Models;

namespace MyLibrary.App.Models
{
    public class IndexPageViewModel
    {
        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string BookStatus { get; set; }

        public static Expression<Func<Book, IndexPageViewModel>> FromBook() =>
            b => new IndexPageViewModel()
            {
                BookId = b.Id,
                BookTitle = b.Title,
                AuthorId = b.AuthorId,
                AuthorName = b.Author.Name,
                BookStatus = b.Status
            };
    }
}
