namespace BookShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using BookShop.Common.Extensions;
    using BookShop.Data;
    using BookShop.Models;
    using BookShop.Services.Contracts;
    using BookShop.Services.Models.Book;
    using Microsoft.EntityFrameworkCore;

    public class BookService : IBookService
    {
        private const int numberOfBooks = 10;

        private readonly BookShopDbContext db;

        public BookService(BookShopDbContext db)
        {
            this.db = db;
        }


        public async Task<int> Create(
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime? releaseDate,
            int аuthorId,
            string categories)
        {

            var book = new Book
            {
                AuthorId = аuthorId,
                Title = title,
                Description = description,
                Price = price,
                Copies = copies,
                Edition = edition,
                ReleaseDate = releaseDate,
                AgeRestriction = ageRestriction
            };

            // Add Categories
            if (!string.IsNullOrWhiteSpace(categories))
            {
                // Get categories
                var categoryNames = categories
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToHashSet();

                var existingCategories = await this.db
                    .Categories
                    .Where(c => categoryNames
                                .Select(cn => cn.ToLower())
                                .Contains(c.Name.ToLower()))
                    .ToListAsync();

                var allCategories = new List<Category>(existingCategories);

                // Create new Categories
                foreach (var categoryName in categoryNames)
                {
                    if (existingCategories.All(c => c.Name.ToLower() != categoryName.ToLower()))
                    {
                        var category = new Category { Name = categoryName };
                        this.db.Categories.Add(category);
                        allCategories.Add(category);
                    }
                }

                await this.db.SaveChangesAsync();

                // Add Categories to Book
                foreach (var category in allCategories)
                {
                    book.Categories.Add(new CategoryBook { CategoryId = category.Id });
                }
            }

            await this.db.AddAsync(book);
            await this.db.SaveChangesAsync();

            return book.Id;
        }

        public async Task<int> Update(
            int id,
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime? releaseDate,
            int аuthorId)
        {
            Book book = this.db.Books.Find(id);


            book.Title = title;
            book.Description = description;
            book.AgeRestriction = ageRestriction;
            book.Price = price;
            book.Copies = copies;
            book.Edition = edition;
            book.ReleaseDate = releaseDate;
            book.AuthorId = аuthorId;

            await this.db.SaveChangesAsync();

            return id;

        }

        public async Task Delete(int id)
        {
            var book = await this.db.Books.FindAsync(id);

            this.db.Books.Remove(book);

            await this.db.SaveChangesAsync();
        }







        public async Task<IEnumerable<BookListingServiceModel>> All(string searchWord)
         => await this.db
                .Books
                .Where(b => b.Title.ToLower().Contains(searchWord.ToLower()))
                .OrderBy(b => b.Title)
                .Take(numberOfBooks)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();


        public async Task<BookDetailsServiceModel> Details(int id)
            => await this.db.Books
                .Where(b => b.Id == id)
                .ProjectTo<BookDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public Task<bool> Exists(int id)
            => this.db.Books.AnyAsync(c => c.Id == id);
    }
}
