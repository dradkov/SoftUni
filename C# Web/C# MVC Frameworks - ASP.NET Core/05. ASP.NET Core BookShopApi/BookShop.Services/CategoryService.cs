namespace BookShop.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using BookShop.Models;
    using BookShop.Services.Contracts;
    using BookShop.Services.Models.Category;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {

        private readonly BookShopDbContext db;

        public CategoryService(BookShopDbContext db)
        {
            this.db = db;
        }


        public async Task<IEnumerable<CategoryListingServiceModel>> All()
            => await this.db
                .Categories
                .OrderBy(c => c.Id)
                .ProjectTo<CategoryListingServiceModel>()
                .ToListAsync();

        public async Task<CategoryDetailsServiceModel> Details(int id)
       => await this.db
                .Categories
                .Where(c => c.Id == id)
                .ProjectTo<CategoryDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<int> Create(string name)
        {
            if (await this.db.Categories.AnyAsync(c => c.Name.ToLower() == name.ToLower()))
            {
                return -1;//this would be an error
            }

            Category category = new Category { Name = name };

            await this.db.Categories.AddAsync(category);

            await this.db.SaveChangesAsync();

            return category.Id;
        }

        public async Task Delete(int id)
        {

            this.db.Categories.Remove(this.db.Categories.Find(id));

            await this.db.SaveChangesAsync();
        }

        public async Task<int> Update(int id,string name)
        {
            if (await this.db.Categories.AnyAsync(c => c.Name.ToLower() == name.ToLower()))
            {
                return -1; //Invalid Operation 
            }

            Category category = this.db.Categories.Find(id);

            if (category == null)
            {
                return -1;
            }

            category.Name = name;

            await this.db.SaveChangesAsync();

            return category.Id;
        }

        public async Task<bool> Exists(int id)
            => await this.db.Categories.AnyAsync(c => c.Id == id);
    }
}
