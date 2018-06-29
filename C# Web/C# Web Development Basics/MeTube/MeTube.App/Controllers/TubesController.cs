namespace MeTube.App.Controllers
{
    using System.Linq;
    using MeTube.App.Models;
    using MeTube.App.Services;
    using MeTube.App.Services.Content;
    using MeTube.Models;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class TubesController : BaseController
    {
        private const string UploadError = "<p>Title and author must be with length  at least3..</p>";

        private readonly ITubeService _tubes;

        public TubesController()
        {
            this._tubes = new TubeService();
        }

        public IActionResult Upload()
        {
            return !this.User.IsAuthenticated ? this.RedirectToHome() : this.View();
        }

        [HttpPost]
        public IActionResult Upload(UploadViewModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError(UploadError);
                return this.View();
            }
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            bool tube = this._tubes.Create(this.User.Name, model.Title, model.Author,GetYouTubeIdFromLink(model.YouTubeLink), model.Description);

            if (tube)
            {
                return this.RedirectToAction($"/tubes/details?id={this.FinsTubeId(model.Title)}");
            }

            this.ShowError(UploadError);
            return this.View();
        }
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            //var kittens = this._kitten
            //    .All()
            //    .Select(k => $@"<div class=""col-4"">
            //                <img class=""img-thumbnail"" src=""{k.Url}"" /><div>
            //                <h5>Name: {k.Name}</h5>
            //                <h5>Age: {k.Age}</h5>
            //                <h5>Breed: {EnumHelper.ConvertEnum(k.Breed)}</h5>
            //            </div>
            //        </div>")
            //    .ToList();

            //var kittensResult = new StringBuilder();
            //kittensResult.Append(@"<div class=""row text-center"">");
            //for (int i = 0; i < kittens.Count; i++)
            //{
            //    kittensResult.Append(kittens[i]);

            //    if (i % 3 == 3 - 1)
            //    {
            //        kittensResult.Append(@"</div><div class=""row text-center"">");
            //    }
            //}

            //kittensResult.Append("</div>");
            //this.Model.Data["kittens"] = kittensResult.ToString();
            return this.View();


        }

        public IActionResult Details(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            Tube tube = this._tubes.TubeExist(id);

            if (tube==null)
            {
               return this.RedirectToHome();
            }

            this._tubes.IncrementTubeViews(tube.Id);

            this.Model.Data["title"] = tube.Title;
            this.Model.Data["youTubeId"] = tube.YouTubeVideo;
            this.Model.Data["author"] = tube.Author;
            this.Model.Data["views"] = tube.Views.ToString();
            this.Model.Data["description"] = tube.Author;

            return this.View();
        }

        private static string GetYouTubeIdFromLink(string youTubeLink)
        {
            string youTubeId = null;
            if (youTubeLink.Contains("youtube.com"))
            {
                youTubeId = youTubeLink.Split("?v=")[1];
            }
            else if (youTubeLink.Contains("youtube"))
            {
                youTubeId = youTubeLink.Split("/").Last();
            }

            return youTubeId;
        }
    }
}
