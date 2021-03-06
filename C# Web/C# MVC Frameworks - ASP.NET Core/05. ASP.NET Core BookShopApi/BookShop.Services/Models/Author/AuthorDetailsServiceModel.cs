﻿namespace BookShop.Services.Models.Author
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BookShop.Common.Mapping;
    using BookShop.Models;

    public class AuthorDetailsServiceModel : IMapFrom<Author>, IHaveCustomMapping
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> Books { get; set; }

        public void ConfigureMapping(Profile mapper)
        {

            mapper
                .CreateMap<Author, AuthorDetailsServiceModel>()
                .ForMember(a => a.Books, cfg => cfg
                    .MapFrom(a => a.Books.Select(b => b.Title)));
           
        }
    }
}
