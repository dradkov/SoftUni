namespace BookShop.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using BookShop.Models;
    using BookShop.Services.Contracts;
    using BookShop.Services.Models.Author;
    using BookShop.Services.Models.Book;
    using Microsoft.EntityFrameworkCore;

    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;

        public AuthorService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BookWithCategoryNamesServiceModel>> All(int authorId)
            => await this.db.Books
                .Where(b => b.AuthorId == authorId)
                .ProjectTo<BookWithCategoryNamesServiceModel>()
                .ToListAsync();

        public async Task<int> Create(string firstName, string lastName)
        {
            Author author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            await this.db.Authors.AddAsync(author);
            await this.db.SaveChangesAsync();

            return author.Id;
        }

        public async Task<AuthorDetailsServiceModel> Details(int id)
            => await this.db
                .Authors
                .Where(a => a.Id == id)
                .ProjectTo<AuthorDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<bool> Exists(int id)
            =>  await this.db.Authors.AnyAsync(a=>a.Id == id);
    }
}

