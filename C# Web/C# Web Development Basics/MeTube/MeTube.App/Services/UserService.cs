namespace MeTube.App.Services
{
    using System.Linq;
    using MeTube.App.Services.Content;
    using MeTube.Data;
    using MeTube.Models;
    using SimpleMvc.Common;

    public class UserService : IUserService
    {
        public bool Create(string username, string password, string email)
        {
            using (MeTubeDbContext db = new MeTubeDbContext())
            {

                if (db.Users.Any(u => u.Username == username && u.Email == email))
                {
                    return false;
                }

                User user = new User
                {
                    Username = username,
                    Email = email,
                    Password = PasswordUtilities.GetPasswordHash(password)
                };

                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool UserExist(string username, string password)
        {
            using (MeTubeDbContext db = new MeTubeDbContext())
            {

                if (db.Users.Any(u => u.Username == username && u.Password == PasswordUtilities.GetPasswordHash(password)))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
