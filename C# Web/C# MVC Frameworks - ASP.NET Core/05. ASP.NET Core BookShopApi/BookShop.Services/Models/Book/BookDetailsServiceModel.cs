namespace BookShop.Services.Models.Book
{
    using System.Linq;
    using AutoMapper;
    using BookShop.Common.Mapping;
    using BookShop.Models;

    public class BookDetailsServiceModel : BookWithCategoryNamesServiceModel, IMapFrom<Book>, IHaveCustomMapping
    {
        public string AuthorName { get; set; }

        public override void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Book, BookDetailsServiceModel>()
                .ForMember(b => b.CategoryNames, cfg => cfg.MapFrom(b => b.Categories
                    .Select(c => c.Category.Name)))
                .ForMember(b => b.AuthorName, cfg => cfg
                    .MapFrom(b => $"{b.Author.FirstName} {b.Author.LastName}"));
        }
    }
}
