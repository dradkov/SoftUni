namespace BankSystem.Client.Core.Commands
{
    using StudentSystem.Data;

    public class LogoutCommand : Command
    {
        public LogoutCommand(BankDbContext db, string[] arguments) : base(db, arguments)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;

            if (!Engine.UserIsLogged)
            {
                result = ErrorMesseges.Denied;
                return result;
            }

            if (this.arguments.Length != 0)
            {
                result = ErrorMesseges.InvalidArgumentsCount;

                return result;
            }

            result = string.Format(SuccessMesseges.Logout, Engine.CurrentUserUsername);

            Engine.CurrentUserId = -1;
            Engine.CurrentUserUsername = string.Empty;
            Engine.UserIsLogged = false;

            return result;
        }
    }
}
