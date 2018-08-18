namespace BookShop.Api.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using BookShop.Api.Infrastructure.Filters;
    using BookShop.Api.Models.Author;
    using BookShop.Services.Contracts;

    using static Helpers.WebConstants;

    public class AuthorsController : BaseApiController
    {
        private readonly IAuthorService _authors;

        public AuthorsController(IAuthorService authors)
        {
            this._authors = authors;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this._authors.Details(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]AuthorRequestModel model)
             => this.Ok(await this._authors.Create(
                        model.FirstName.Trim(),
                        model.LastName.Trim()));


        [HttpGet(WithId + "/books")]
        public async Task<IActionResult> GetBooks(int id)
            => this.OkOrNotFound(await this._authors.All(id));

    }
}
