namespace PhotoShare.Services
{
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using PhotoShare.Data;
    using System.Linq;
    using System;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly PhotoShareContext context;

        public UserService(PhotoShareContext context)
        {
            this.context = context;
        }

        public User FindById(int id)
        {
            var user = context.Users.Find(id);

            return user;
        }

        public User FindByUsername(string username)
        {
            var user = context.Users
                .SingleOrDefault(u => u.Username == username);

            return user;
        }

        public User FindByUsernameAndPassword(string username, string password)
        {
            var user = context.Users
                .SingleOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }

        public string DeleteUser(string username)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (user.IsDeleted.Value)
            {
                throw new InvalidOperationException($"User {username} is already deleted!");
            }

            user.IsDeleted = true;

            context.SaveChanges();

            return $"User {username} was deleted successfully!";
        }

        public string ListFriends(string username)
        {
            var user = FindByUsername(username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var friends = context.Users
                .SingleOrDefault(u => u.Username == username).FriendsAdded.Select(fd => fd.Friend)
                .ToList();

            if (friends.Count == 0)
            {
                return "No friends for this user. :(";
            }

            var result = "Friends:" + Environment.NewLine + string.Join(Environment.NewLine, friends.Select(f => "-" + f.Username));

            return result;
        }

        public string RegisterUser(string username, string password, string repeatedPassword, string email)
        {
            if (context.Users.Any(u => u.Username == username))
            {
                throw new InvalidOperationException($"Username {username} is already taken!");
            }

            if (password != repeatedPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            context.Users.Add(user);

            context.SaveChanges();

            return $"User {username} was registered successfully!";
        }

        public string ModifyUser(string username, string property, string newValue)
        {
            var user = FindByUsername(username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }
            string prop = ModifyUser(property, newValue, user);

            context.SaveChanges();

            return $"User {username} {prop} is {newValue}.";
        }

        private string ModifyUser(string property, string newValue, User user)
        {
            string prop;

            switch (property)
            {
                case "Password":
                    if (newValue.Length < 2 || (!newValue.Any(c => char.IsDigit(c)) || !newValue.Any(c => char.IsLower(c))))
                    {
                        throw new ArgumentException($"Value {newValue} not valid." + Environment.NewLine + $"Invalid Password");
                    }
                    prop = "Password";
                    user.Password = newValue;
                    break;
                case "CurrentTown":
                    var town = FindTownByName(newValue);
                    if (town == null)
                    {
                        throw new ArgumentException($"Value {newValue} not valid." + Environment.NewLine + $"Town {newValue} not found!");
                    }
                    prop = "CurrentTown";
                    user.CurrentTown = town;
                    break;
                case "BornTown":
                    town = FindTownByName(newValue);
                    if (town == null)
                    {
                        throw new ArgumentException($"Value {newValue} not valid." + Environment.NewLine + $"Town {newValue} not found!");
                    }
                    prop = "BornTown";
                    user.BornTown = town;
                    break;
                default:
                    throw new ArgumentException($"Property {property} not supported!");
            }

            return prop;
        }

        private Town FindTownByName(string townName)
        {
            var town = context.Towns
                .SingleOrDefault(u => u.Name == townName);

            return town;
        }

        public string PrintFriends(string username)
        {
            var user = GetUser(username);

            UserExists(username, user);

            if (user.FriendsAdded.Count() == 0)
            {
                return "No friends for this user. :(";
            }
            var friends = user.FriendsAdded.ToList();

            var result = "Friends:" + Environment.NewLine + string.Join(Environment.NewLine, friends.Select(f => "-" + f.Friend.Username));

            return result;
        }

        private static void UserExists(string username, User user)
        {
            if (user == null)
            {
                throw new ArgumentException($"{username} not found!");
            }
        }

        private User GetUser(string username)
        {
            return context.Users.Include(u => u.FriendsAdded).ThenInclude(fa => fa.Friend)
                .SingleOrDefault(u => u.Username == username);
        }
    }
}