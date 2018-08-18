namespace BookShop.Api.Controllers
{
    using System.Threading.Tasks;
    using BookShop.Api.Infrastructure.Extensions;
    using BookShop.Api.Infrastructure.Filters;
    using BookShop.Api.Models.Category;
    using BookShop.Services.Contracts;
    using BookShop.Services.Models.Category;
    using Microsoft.AspNetCore.Mvc;
    using static Helpers.WebConstants;

    public class CategoriesController : BaseApiController
    {

        private readonly ICategoryService _categories;

        public CategoriesController(ICategoryService categories)
        {
            this._categories = categories;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => this.OkOrNotFound(await this._categories.All());

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
        {
            bool categoryExist = await this._categories.Exists(id);

            if (!categoryExist)
            {
                return this.BadRequest($"Category with Id {id} doesn't exist");
            }

            return this.Ok(await this._categories.Details(id));

        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] CategoryRequestModel model)
            => this.Ok(await this._categories.Create(model.Name));


        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            bool categoryExist =  await this._categories.Exists(id);

            if (!categoryExist)
            {
                return this.BadRequest($"Category with given id {id} doesn't exist ");
            }

            await this._categories.Delete(id);

            return this.Ok(id);
        }

        [HttpPut(WithId)]
        public async Task<IActionResult> Put(int id,[FromBody]CategoryDetailsServiceModel model)
        {
            bool categoryExist = await this._categories.Exists(id);

            if (!categoryExist)
            {
                return this.BadRequest($"Category with given id {id} doesn't exist ");

            }         
            return this.Ok(await this._categories.Update(id,model.Name));
        }
       
    }
}
