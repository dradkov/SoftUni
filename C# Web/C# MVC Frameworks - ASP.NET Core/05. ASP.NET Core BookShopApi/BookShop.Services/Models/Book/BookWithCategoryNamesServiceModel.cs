namespace BookShop.Services.Models.Book
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BookShop.Common.Mapping;
    using BookShop.Models;

    public class BookWithCategoryNamesServiceModel : IMapFrom<Book>,IHaveCustomMapping
    {
        public int Id { get; set; }
    
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public int? Edition { get; set; } = 1;

        public int? AgeRestriction { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public IEnumerable<string> CategoryNames { get; set; }

        public virtual void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Book, BookWithCategoryNamesServiceModel>()
                .ForMember(b => b.CategoryNames,
                    cfg => cfg.MapFrom(b => b.Categories
                        .Select(c=>c.Category.Name)));
        }
    }
}
