namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using Remotion.Linq.Parsing.Structure.IntermediateModel;

    public class StartUp
    {
        public static void Main()
        {
            //using (var db = new BookShopContext())
            //{
            //   // DbInitializer.ResetDatabase(db);         

            //}

            var db = new BookShopContext();

            using (db)
            {


            }

        }

        //15
        public static int RemoveBooks(BookShopContext db)
        {

            var books = db.Books.Where(b => b.Copies < 4200).ToList();

            //db.Books.RemoveRange(db.Books.Where(b=>b.Copies<4200));

            foreach (var book in books)
            {
                db.Books.Remove(book);
            }

            db.SaveChanges();

            return books.Count;
        }

        //14
        public static void IncreasePrices(BookShopContext db)
        {
            var books = db.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

        }

        //13
        public static string GetMostRecentBooks(BookShopContext db)
        {
            var books = db.Categories.Select(e => new
            {
                CategoryName = e.Name,
                TotalBookCount = e.CategoryBooks.Count,
                CategoriBook = e.CategoryBooks.OrderByDescending(x => x.Book.ReleaseDate.Value).Take(3)
                    .Select(k => new
                    {
                        BoolTitle = k.Book.Title,
                        BookYear = k.Book.ReleaseDate.Value.Year
                    })
                    .OrderByDescending(j => j.BookYear)
            })
                .OrderBy(e => e.CategoryName)
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"--{book.CategoryName}");
                foreach (var bo in book.CategoriBook)
                {
                    sb.AppendLine($"{bo.BoolTitle} ({bo.BookYear})");
                }
            }

            return sb.ToString().Trim();
        }

        //12
        public static string GetTotalProfitByCategory(BookShopContext db)
        {
            var books = db.Categories
                .Select(e => new
                {
                    CategoryName = e.Name,
                    TotalProfit = e.CategoryBooks.Sum(c => c.Book.Copies * c.Book.Price)
                })
                .OrderByDescending(e => e.TotalProfit)
                .ThenBy(e => e.CategoryName)
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.CategoryName} ${book.TotalProfit:f2}");
            }

            return sb.ToString().Trim();
        }

        //11
        public static string CountCopiesByAuthor(BookShopContext db)
        {
            var books = db.Books
                .Select(e => new
                {
                    Name = e.Author.FirstName + " " + e.Author.LastName,
                    TotalCopies = e.Copies

                })
            .GroupBy(x => x.Name)
            .OrderByDescending(x => x.Sum(c => c.TotalCopies))
            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in books)
            {
                sb.AppendLine($"{author.Key} - {author.Sum(x => x.TotalCopies)}");
            }
            return sb.ToString().Trim();
        }

        //10
        public static int CountBooks(BookShopContext db, int lengthCheck)
        {

            var books = db.Books.Where(b => b.Title.Length > lengthCheck).ToList();

            return books.Count;
        }


        //09
        public static string GetBooksByAuthor(BookShopContext db, string input)
        {
            var books = db.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.AuthorId)
                .Select(e => new
                {
                    BookTitle = e.Title,
                    FullName = e.Author.FirstName + " " + e.Author.LastName
                })
                .ToList();



            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.BookTitle} ({book.FullName})");
            }

            return sb.ToString().Trim();
        }

        //08
        public static string GetBookTitlesContaining(BookShopContext db, string input)
        {

            var books = db.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .Select(e => e.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //07
        public static string GetAuthorNamesEndingIn(BookShopContext db, string input)
        {
            var books = db.Books.Where(b => b.Author.FirstName.EndsWith(input))
                .OrderBy(x => x.Author.FirstName)
                .ThenBy(x => x.Author.LastName)
                .Select(n => new
                {
                    FullName = n.Author.FirstName + " " + n.Author.LastName

                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books.Distinct())
            {
                sb.AppendLine($"{book.FullName}");
            }
            return sb.ToString().Trim();
        }

        //06
        public static string GetBooksReleasedBefore(BookShopContext db, string date)
        {
            string[] splitDate = date.Split(new[] { '-', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            DateTime dateTime = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));

            var books = db.Books
                .Where(b => b.ReleaseDate.Value.Date < dateTime)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(e => new
                {
                    BookTitle = e.Title,
                    BookEditionType = e.EditionType,
                    BookPrice = e.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.BookTitle} - {book.BookEditionType} - ${book.BookPrice:f2}");
            }
            return sb.ToString().Trim();
        }


        //05
        public static string GetBooksByCategory(BookShopContext db, string input)
        {


            string[] splitString = input.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> categories = new List<string>();

            foreach (var cat in splitString)
            {
                categories.Add(cat.Substring(0, 1).ToUpper() + cat.Substring(1));
            }

            var books = db.Books
                .Where(b => b.BookCategories
                    .Select(c => c.Category.Name)
                    .Intersect(categories).Any())
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }


        //04
        public static string GetBooksNotRealeasedIn(BookShopContext db, int year)
        {

            var books = db.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(i => i.BookId)
                .Select(e => e.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //03
        public static string GetBooksByPrice(BookShopContext db)
        {
            var books = db.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    TitleBook = b.Title,
                    PriceBook = b.Price
                })
                .ToArray();


            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.TitleBook} - ${book.PriceBook:f2}");
            }
            return sb.ToString().Trim();
        }

        //02
        public static string GetGoldenBooks(BookShopContext db)
        {

            var books = db.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(g => g.BookId)
                .Select(e => e.Title).ToList();

            return string.Join(Environment.NewLine, books);
        }

        //01
        public static string GetBooksByAgeRestriction(BookShopContext db, string command)
        {


            var comandLine = Enum.Parse<AgeRestriction>(command, ignoreCase: true);


            var books = db.Books
                .Where(x => x.AgeRestriction == comandLine)
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);



        }
    }
}
