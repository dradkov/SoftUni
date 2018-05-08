namespace BankSystem.Client.Core
{
    public static class ErrorMesseges
    {
        public const string NoUserLogedIn = "User Not Found";


        public const string InvalidPassword = "Password must contain at least 1 lowercase letter, 1 uppercase letter and 1 digit. Also, must be more than 6 symbols long";

        public const string InvalidEmail = "Please type correct email";

        public const string InvalidUser = "Username must contain only words and digits .The length must be atleast 3 symbols";


        public const string IncorectLogin = "Incorrect username or password";

        public const string Denied = "Cannot log out. No user was logged in.";

        public const string UserIsLogged = "You cannot {0} while logged in!";

        public const string InvalidArgumentsCount = "Invalid Arguments Count!";

        public const string UserExists = "Invalid Arguments Count!";


        public const string InvalidCommand = "Command {0} doesn't exist";

        public const string InvalidAccount = "Account {0} doesn't exist";




    }
}
