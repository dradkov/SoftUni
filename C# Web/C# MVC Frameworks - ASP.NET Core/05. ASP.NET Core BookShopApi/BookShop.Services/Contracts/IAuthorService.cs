namespace BookShop.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookShop.Services.Models.Author;
    using BookShop.Services.Models.Book;

    public interface IAuthorService
    {
        Task<IEnumerable<BookWithCategoryNamesServiceModel>> All(int authorId);

        Task<int> Create(string firstName, string lastName);

        Task<AuthorDetailsServiceModel> Details(int id);

        Task<bool> Exists(int id);
    }
}
