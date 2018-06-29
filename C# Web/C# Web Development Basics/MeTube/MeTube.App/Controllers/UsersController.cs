namespace MeTube.App.Controllers
{
    using System.Text;
    using MeTube.App.ErrorMesseges;
    using MeTube.App.Models;
    using MeTube.App.Services;
    using MeTube.App.Services.Content;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class UsersController : BaseController
    {
        private readonly IUserService _users;
        private readonly ITubeService _tubes;

        public UsersController()
        {
            this._users = new UserService();
            this._tubes = new TubeService();
        }
        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError(ErrorMessege.RegisterError);
                return this.View();
            }

            bool createUser = this._users.Create(model.Username, model.Password, model.Email);

            if (createUser)
            {
                this.SignIn(model.Username, this.FindUserId(model.Username));
                return this.RedirectToHome();
            }

            this.ShowError(ErrorMessege.RegisterError);
            return this.View();
        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError(ErrorMessege.LoginBoxes);
                return this.View();
            }

            bool logUser = this._users.UserExist(model.Username, model.Password);
            if (logUser)
            {
                this.SignIn(model.Username, this.FindUserId(model.Username));
                return this.RedirectToHome();
            }

            this.ShowError(string.Format(ErrorMessege.LoginError, model.Username));
            return this.View();
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var userId = this.FindUserId(this.User.Name);

            var tubes = this._tubes.ProfileTubes(userId);

            this.Model.Data["username"] = this.User.Name;
            this.Model.Data["email"] = "usermail";

            var tubesResult = new StringBuilder();
            foreach (var tube in tubes)
            {
                tubesResult.AppendLine(
                    $@"<tr>
                        <td>{tube.Id}</td>
                        <td>{tube.Title}</td>
                        <td>{tube.Author}</td>
                        <td><a href=""/tubes/details?id={tube.Id}"">Details</a></td>
                    </tr>");
            }

            this.Model.Data["tubes"] = tubesResult.ToString();

            return this.View();
        }
    }
}
