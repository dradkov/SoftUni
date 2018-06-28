namespace Kittens.App.Services
{
    using System.Linq;
    using Kittens.App.Services.Content;
    using Kittens.Data;
    using Kittens.Models;
    using Microsoft.EntityFrameworkCore.Internal;
    using SimpleMvc.Common;

    public class UserService : IUserService
    {
        public bool Create(string username, string email, string password, string confirmPassword)
        {
            using (KittenDbContext db = new KittenDbContext())
            {

                if (db.Users.Any(u => u.Username == username && u.Email == email))
                {
                    return false;
                }

                User user = new User
                {
                    Username = username,
                    Email = email,
                    Password = password
                };

                db.Users.Add(user);
                db.SaveChanges();


                return true;
            }
        }

        public bool UserLogin(string username, string password)
        {
            using (KittenDbContext db = new KittenDbContext())
            {
                return db.Users.Any(u => u.Username == username || u.Password == password);
            }
        }
    }
}
