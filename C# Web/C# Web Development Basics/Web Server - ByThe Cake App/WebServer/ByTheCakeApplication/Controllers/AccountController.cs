namespace WebServer.ByTheCakeApplication.Controllers
{
    using System.Collections.Generic;
    using Infrastructure;
    using Server.Http.Contracts;

    public class AccountController : Controller
    {

        public IHttpResponse Login()
        {
            var loginValues = new Dictionary<string, string>
            {
                ["result"] = string.Empty,
            };

            return this.FileViewResponse(@"account\login", loginValues);
        }

        public IHttpResponse Login(string username, string password)
        {
            const string loginMessage = "Hi {0}, your password is {1}";
            var result = string.Format(loginMessage, username, password);

            var loginValues = new Dictionary<string, string>
            {
                ["result"] = result
            };

            return this.FileViewResponse(@"account\login", loginValues);
        }

        public IHttpResponse AdminLogin()
        {
            var loginValues = new Dictionary<string, string>
            {
                ["result"] = string.Empty,
            };

            return this.FileViewResponse(@"account\login", loginValues);
        }
        public IHttpResponse AdminLogin(string username, string password)
        {


            const string ValidUsername = "suAdmin";
            const string ValidPassword = "aDmInPw17";
            const string LoginMessageSuccess = "Hello {0}!";
            const string LoginMessageFailure = "Invalid username or password!";

            var result = LoginMessageFailure;
            if (username == ValidUsername && password == ValidPassword)
            {
                result = string.Format(LoginMessageSuccess, username);
            }

            var loginValues = new Dictionary<string, string>
            {
                ["result"] = result
            };

            return this.FileViewResponse(@"account\sendEmail", loginValues);
        }
        public IHttpResponse SendEmail()
        {
            var emailValues = new Dictionary<string, string>
            {
                ["result"] = string.Empty,
            };

            return this.FileViewResponse(@"account\sendEmail", emailValues);
        }

        public IHttpResponse SendEmail(string recepient, string subject, string message)
        {
            var emailValues = new Dictionary<string, string>
            {
                ["result"] = "Test",
            };

            return this.FileViewResponse(@"account\sendEmail", emailValues);
        }
    }
}
