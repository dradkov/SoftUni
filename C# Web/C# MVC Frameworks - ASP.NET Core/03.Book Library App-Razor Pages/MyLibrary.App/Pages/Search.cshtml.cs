using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.App.BasePageModels;
using MyLibrary.App.Models;
using MyLibrary.Data;

namespace MyLibrary.App.Pages
{
    public class SearchModel : BasePageModel
    {
        public SearchModel(MyLibraryContext context)
            :base(context)
        {
            this.SearchResults = new List<SearchViewModel>();
        }

        [BindProperty]
        public List<SearchViewModel> SearchResults { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public void OnGet(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return;
            }
            this.SearchTerm = searchTerm;

            var foundAuthors = this.Context.Authors
                .Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()))
                .OrderBy(a => a.Name)
                .Select(a => new SearchViewModel()
                {
                    Id = a.Id,
                    SearchResult = a.Name,
                    Type = "Author"
                }).ToList();
            var foundBooks = this.Context.Books
                .Where(b => b.Title.ToLower().Contains(searchTerm.ToLower()))
                .OrderBy(b => b.Title)
                 .Select(b => new SearchViewModel()
                 {
                     Id = b.Id,
                     SearchResult = b.Title,
                     Type = "Book"
                 }).ToList();

            this.SearchResults.AddRange(foundAuthors);
            this.SearchResults.AddRange(foundBooks);

            foreach (var result in SearchResults)
            {
                result.SearchResult = Regex.Replace(
                    result.SearchResult, 
                    Regex.Escape($"({SearchTerm})"),
                    $@"<strong class=""text-danger"">{SearchTerm}</strong>",
                    RegexOptions.IgnoreCase);
            }
        }
    }
}