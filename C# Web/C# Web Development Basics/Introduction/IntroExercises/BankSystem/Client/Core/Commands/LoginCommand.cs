using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Client.Core.Commands
{
    using System.Linq;
    using BankSystem.Models;
    using StudentSystem.Data;

    public class LoginCommand : Command
    {
        public LoginCommand(BankDbContext db, string[] arguments) : base(db, arguments)
        {
        }

        public override string Execute()
        {

            string result = string.Empty;

            if (Engine.UserIsLogged)
            {
                result = string.Format(ErrorMesseges.UserIsLogged, "login twise");
                return result;
            }

            if (this.arguments.Length != 2)
            {
                result = ErrorMesseges.InvalidArgumentsCount;

                return result;
            }

            string username = this.arguments[0];

            string password = this.arguments[1];

            if (this.db.Users.Any(u => u.Username == username && u.Password == password))
            {
                var user = this.db.Users
                    .Where(u => u.Username == username && u.Password == password)
                    .Select(u => new
                    {

                        u.Id,
                        u.Username

                    }).First();

                Engine.CurrentUserId = user.Id;
                Engine.CurrentUserUsername =user.Username;
                Engine.UserIsLogged = true;

                result = string.Format(SuccessMesseges.Login, username);
            }
            else
            {
                result = ErrorMesseges.IncorectLogin;
                return result;
            }

            return result;
        }
    }
}
