namespace BankSystem.Client.Core.Commands
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using BankSystem.Models;
    using StudentSystem.Data;

    public class RegisterCommand : Command
    {
        private const string UsernamePattern = @"^[a-zA-Z][a-zA-Z0-9]{2,}$";
        private const string PasswordPattern = @"^(?=[^\s]*[a-z])(?=[^\s]*[A-Z])(?=[^\s]*\d)[a-zA-Z0-9]{7,}$";
        private const string EmailPattern = @"^([a-zA-Z0-9]+[.-_]?[a-zA-Z0-9]+)(@)[a-zA-Z0-9]+[-]?[a-zA-Z0-9]+(\.[a-zA-Z0-9]{2,})+$";


        public RegisterCommand(BankDbContext db, string[] arguments) : base(db, arguments)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;

            if (Engine.UserIsLogged)
            {
                result = string.Format(ErrorMesseges.UserIsLogged, "register a user");

                return result;
            }

            if (this.arguments.Length != 3)
            {
                result = ErrorMesseges.InvalidArgumentsCount;

                return result;
            }

            string username = this.arguments[0];
            string password = this.arguments[1];
            string email = this.arguments[2];

            if (!Regex.IsMatch(username, UsernamePattern))
            {
                result = ErrorMesseges.InvalidUser;
                return result;
            }

            if (!Regex.IsMatch(password, PasswordPattern))
            {
                result = ErrorMesseges.InvalidPassword;
                return result;
            }

            if (!Regex.IsMatch(email, EmailPattern))
            {
                result = ErrorMesseges.InvalidEmail;
                return result;
            }

            if (db.Users.Any(u => u.Username == username))
            {
                result = string.Format(ErrorMesseges.UserExists, username);

                return result;
            }

            var user = new User()
            {
                Username = username,
                Email = email,
                Password = password
            };

            db.Users.Add(user);
            db.SaveChanges();

            result = string.Format(SuccessMesseges.UserRegistered, username);

            return result;
        }
    }
}
