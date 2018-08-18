namespace BookShop.Api.Models.Category
{
    using BookShop.Common.Mapping;
    using BookShop.Models;

    public class CategoryRequestModel : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}
