namespace BookShop.Services.Contracts
{
    using BookShop.Services.Models.Category;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListingServiceModel>> All();

        Task<CategoryDetailsServiceModel> Details(int id);

        Task<int> Create(string name);

        Task Delete(int id);

        Task<int> Update (int id,string name);

        Task<bool> Exists(int id);

    }
}
