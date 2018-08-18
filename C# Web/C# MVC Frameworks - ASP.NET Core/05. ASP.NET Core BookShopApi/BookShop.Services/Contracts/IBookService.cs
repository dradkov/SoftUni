namespace BookShop.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookShop.Services.Models.Book;

    public interface IBookService
    {

        Task<int> Create(
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime? рeleaseDate,
            int аuthorId,
            string categories);

        Task<int> Update(
            int id,
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime? рeleaseDate,
            int аuthorId);

        Task Delete(int id);

        Task<IEnumerable<BookListingServiceModel>> All(string searchWord);


        Task<BookDetailsServiceModel> Details(int id);

        Task<bool> Exists(int id);
    }
}
