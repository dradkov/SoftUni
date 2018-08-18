namespace BookShop.Services.Models.Category
{
    using BookShop.Common.Mapping;
    using BookShop.Models;

    public class CategoryListingServiceModel : IMapFrom<Category>

    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
