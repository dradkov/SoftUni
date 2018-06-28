namespace Kittens.App.Controllers
{
    using Kittens.App.Models.Users;
    using Kittens.App.Services;
    using Kittens.App.Services.Content;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using System.Linq;

    public class UsersController : BaseController
    {
        private const string RegisterError = "<p>Invalid Information</p>";
        private const string LoginDataError = "<p> Username must be with more than 3 and less then 6 symbols . Password length must be more than 3 symbols</p>";
        private const string LoginError = "<p>This user Doesn't exist</p>";

        private readonly IUserService _users;

        public UsersController()
        {
            this._users = new UserService();

        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError(RegisterError);
                return this.View();
            }



            bool createUser = this._users.Create(model.Username, model.Email, model.Password, model.ConfirmPassword);

            if (createUser)
            {
                int userId = this.FindUser(model.Username);

                this.SignIn(model.Username, userId);

               return this.RedirectToHome();
            }

            return this.View();
        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError(LoginDataError);
                return this.View();
            }


            bool existeUser = this._users.UserLogin(model.Username, model.Password);

            if (existeUser)
            {
                int userId = this.FindUser(model.Username);

                this.SignIn(model.Username, userId);
                return this.RedirectToHome();
            }
            this.ShowError(LoginError);
            return this.View();
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.RedirectToHome();
        }


    }
}
