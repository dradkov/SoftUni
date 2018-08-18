namespace BookShop.Api.Controllers
{
    using System.Threading.Tasks;
    using BookShop.Api.Infrastructure.Extensions;
    using BookShop.Api.Infrastructure.Filters;
    using BookShop.Api.Models.Book;
    using BookShop.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    using static Helpers.WebConstants;

    public class BooksController : BaseApiController
    {
        private readonly IBookService _books;
        private readonly IAuthorService _authors;

        public BooksController(IBookService books, IAuthorService authors)
        {
            this._books = books;
            this._authors = authors;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this._books.Details(id));

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string searchWord = "")
            => this.OkOrNotFound(await this._books.All(searchWord));


        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] BookWithCategoriesRequestModel model)
        {

            var authorExist = await this._authors.Exists(model.AuthorId);

            if (!authorExist)
            {
                return this.BadRequest("Author does not exist.");
            }

            int bookId = await this._books.Create(
                model.Title,
                model.Description,
                model.Price,
                model.Copies,
                model.Edition,
                model.AgeRestriction,
                model.ReleaseDate,
                model.AuthorId, model.Categories);

            return this.Ok(bookId);
        }

        [HttpPut(WithId)]
        public async Task<IActionResult> Put(int id, [FromBody] BookRequestModel model)
        {
            var bookExists = await this._books.Exists(id);

            if (!bookExists)
            {
                return this.BadRequest("The book does't exist");
            }

            var authorExists = await this._authors.Exists(model.AuthorId);

            if (!authorExists)
            {
                return this.BadRequest("The book does't exist");

            }

            int bookId = await this._books.Update(
                                     id,
                                     model.Title,
                                     model.Description,
                                     model.Price,
                                     model.Copies,
                                     model.Edition,
                                     model.AgeRestriction,
                                     model.ReleaseDate,
                                     model.AuthorId);

            return this.Ok(bookId);
        }

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            bool bookExist = await this._books.Exists(id);

            if (!bookExist)
            {
               return this.BadRequest("Book doesn't exist");
            }

           await this._books.Delete(id);

           return this.Ok(id);
        }

    }
}
