namespace Kittens.App.Controllers
{
    using System.Linq;
    using Kittens.Data;
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

        protected KittenDbContext KittenDb { get; set; } = new KittenDbContext();

        protected void ShowError(string error)
        {
            
            this.Model.Data["show-error"] = "flex";
            this.Model.Data["error"] = error;
        }

        protected int FindUser(string modelUsername)
        {
            using (this.KittenDb)
            {
              return  this.KittenDb.Users.FirstOrDefault(u => modelUsername != null && u.Username == modelUsername).Id;
            }
        }
       

        protected IActionResult RedirectToHome()
            => this.RedirectToAction("/");

        public override void OnAuthentication()
        {

            if (this.User.IsAuthenticated)
            {
                this.Model.Data["anonymousDisplay"] = "none";
                this.Model.Data["userDisplay"] = "flex";
            }
           
            base.OnAuthentication();
        }
      
    }
}
