namespace Kittens.App.Controllers
{
    using System.Linq;
    using System.Text;
    using Kittens.App.Helper;
    using Kittens.App.Models.Kittens;
    using Kittens.App.Services;
    using Kittens.App.Services.Content;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Attributes.Security;
    using SimpleMvc.Framework.Interfaces;

    public class KittensController : BaseController
    {
        private const string IncorrectData = "<p>Name must be more then 3 symbols.Age must be in range 0-18.Breed must be Street Transcended, American Shorthair ,Munchkin or Siamese <p>";
        private readonly IKittenService _kitten;

        public KittensController()
        {
            this._kitten = new KittenService();

        }

        public IActionResult Add()
        {
            return !this.User.IsAuthenticated ? this.RedirectToHome() : this.View();
        }

        [HttpPost]
        public IActionResult Add(AddKittenViewModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError(IncorrectData);
                return this.View();
            }



            bool createCat = this._kitten.Create(model.Name, model.Age, model.Breed);

            if (createCat)
            {
                return this.RedirectToAction("/kittens/all");
            }

            this.ShowError(IncorrectData);
            return this.View();
        }

        [PreAuthorize]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }


            var kittens = this._kitten
                .All()
                .Select(k => $@"<div class=""col-4"">
                            <img class=""img-thumbnail"" src=""{k.Url}"" /><div>
                            <h5>Name: {k.Name}</h5>
                            <h5>Age: {k.Age}</h5>
                            <h5>Breed: {EnumHelper.ConvertEnum(k.Breed)}</h5>
                        </div>
                    </div>")
                .ToList();

            var kittensResult = new StringBuilder();
            kittensResult.Append(@"<div class=""row text-center"">");
            for (int i = 0; i < kittens.Count; i++)
            {
                kittensResult.Append(kittens[i]);

                if (i % 3 == 3 - 1)
                {
                    kittensResult.Append(@"</div><div class=""row text-center"">");
                }
            }

            kittensResult.Append("</div>");
            this.Model.Data["kittens"] = kittensResult.ToString();
            return this.View();
        }
    }
}
