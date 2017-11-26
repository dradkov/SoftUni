namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Contracts;


    class LogoutCommand : ICommand
    {
        public string Execute(string command, params string[] data)
        {
            if (Session.User == null)
            {
                return "You should log in first in order to logout.";
            }

            string username = Session.User.Username;

            Session.User = null;

            return $"User {username} successfully logged out!";
        }
    }
}