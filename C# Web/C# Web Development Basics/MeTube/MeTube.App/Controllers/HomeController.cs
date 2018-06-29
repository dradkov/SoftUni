namespace MeTube.App.Controllers
{
    using System.Text;
    using MeTube.App.Services;
    using MeTube.App.Services.Content;
    using SimpleMvc.Framework.Interfaces;

    public class HomeController : BaseController
    {
        private readonly ITubeService _tubes;

        public HomeController()
        {
            this._tubes = new TubeService();
        }
        public IActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {

                var tubes = this._tubes.All();

                var tubesResult = new StringBuilder();
                tubesResult.Append(@"<div class=""row text-center"">");
                for (int i = 0; i < tubes.Count; i++)
                {
                    var tube = tubes[i];
                    tubesResult.Append(
                        $@"<div class=""col-4"">
                            <img class=""img-thumbnail tube-thumbnail"" src=""https://img.youtube.com/vi/{tube.YouTubeId}/0.jpg"" alt=""{tube.Title}"" />
                            <div>
                                <h5>{tube.Title}</h5>
                                <h5>{tube.Author}</h5>
                            </div>
                        </div>");

                    if (i % 3 == 2)
                    {
                        tubesResult.Append(@"</div><div class=""row text-center"">");
                    }
                }

                tubesResult.Append("</div>");

                this.Model.Data["result"] = tubesResult.ToString();

            }
            else
            {
                this.Model.Data["result"] =
                    @"<div class=""jumbotron"">
                        <p class=""h1 display-3"">Welcome to MeTube&trade;!</p>
                        <p class=""h3"">The simplest, easiest to use, most comfortable Multimedia Application.</p>
                        <hr class=""my-3"">
                        <p><a href=""/users/login"">Login</a> if you have an account or <a href=""/users/register"">Register</a> now and start tubing.</p>
                    </div>";
            }

            return this.View();
        }

    }
}
