namespace MeTube.App.Controllers
{
    using System.Linq;
    using MeTube.Data;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public abstract class BaseController : Controller
    {

        protected BaseController()
        {
            this.Model.Data["anonymousDisplay"] = "flex";
            this.Model.Data["userDisplay"] = "none";
            this.Model.Data["show-error"] = "none";
        }

        protected void ShowError(string error)
        {
            this.Model.Data["show-error"] = "block";
            this.Model.Data["error"] = error;
        }

        protected MeTubeDbContext TubeDb { get; set; } = new MeTubeDbContext();

        protected int FindUserId(string username)
        {
            using (this.TubeDb)
            {
                return this.TubeDb.Users.FirstOrDefault(u => u.Username == username).Id;
            }
        }

        protected int FinsTubeId(string tubeName)
        {
            using (this.TubeDb)
            {
                return this.TubeDb.Tubes.FirstOrDefault(t => t.Title == tubeName).Id;
            }
        }


        public override void OnAuthentication()
        {

            if (this.User.IsAuthenticated)
            {
                this.Model.Data["anonymousDisplay"] = "none";
                this.Model.Data["userDisplay"] = "flex";
            }

            base.OnAuthentication();
        }

        protected IActionResult RedirectToHome() => this.RedirectToAction("/");

        protected IActionResult RedirectToAllTubes() => this.RedirectToAction("/tubes/all");
    }
}
