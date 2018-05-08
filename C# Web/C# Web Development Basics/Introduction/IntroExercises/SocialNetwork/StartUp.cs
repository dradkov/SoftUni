namespace SocialNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SocialNetwork.Data;
    using SocialNetwork.Data.Models;
    using SocialNetwork.Data.Models.Enums;
    using SocialNetwork.Data.Models.TagValidation;

    public class StartUp
    {
        public static void Main()
        {
            using (SocialNetworkDbContext db = new SocialNetworkDbContext())
            {
                SetUpDataBase(db);
                SeedSomeData(db);

                //ListUsersWithFriends(db);
                //ListActiveUsersWithFriends(db);
                //ListAlbums(db);
                //ListPictureInSeveralAlbums(db);
                //ListAllAlbums(db, 1);
                //ListUsersSharedAlbums(db);
                //ListSharedAlbums(db);
                //ListAlbumsSharedWithUser(db);
                //ListUserAlbumInformation(db);
                //ListAllAlbumsWithUser(db);
                //ListUsersAndAlbumViewers(db);
                //RegisterUserTags(db);
                //ListAlbumByGivenTag(db, "#summer");
                //ListUsersWithMoreThan3Tags(db);
            }
        }


        //01 Friends
        private static void ListUsersWithFriends(SocialNetworkDbContext db)
        {
            var users = db.Users.Select(u => new
            {
                u.Username,
                Friends = u.Firends.Count,
                u.IsDeleted
            }).OrderByDescending(u => u.Friends).ThenBy(u => u.Username).ToArray();

            string status;
            foreach (var u in users)
            {
                status = (u.IsDeleted == false) ? "InActive" : "Active"; ;

                Console.WriteLine($"Name {u.Username} Num of friends: {u.Friends} Status {status}");

            }
        }


        //02 Friends
        private static void ListActiveUsersWithFriends(SocialNetworkDbContext db)
        {
            var users = db.Users
                .Where(u => u.IsDeleted == false && u.Firends.Count > 5)
                .Select(u => new
                {
                    u.Username,
                    u.RegisteredOn,
                    FriendCount = u.Firends.Count

                }).OrderBy(u => u.RegisteredOn).ThenByDescending(u => u.FriendCount).ToArray();

            foreach (var u in users)
            {
                Console.WriteLine($"User : {u.Username} Friends Num {u.FriendCount}");
                Console.WriteLine($"    Period  {(DateTime.Now - u.RegisteredOn).Days}");
            }
        }

        //01 Albums
        private static void ListAlbums(SocialNetworkDbContext db)
        {

            var user = db.Users.Select(u => new
            {
                u.Username,
                CountPics = u.Albums.Select(p => new
                {
                    Pics = p.Album.Pictures.Count,
                    Title = p.Album.Name,

                }).OrderByDescending(s => s.Pics)
            }).OrderBy(u => u.Username).ToArray();


            foreach (var a in user)
            {
                Console.WriteLine($"Owner {a.Username}");
                foreach (var p in a.CountPics)
                {
                    Console.WriteLine($"AlbumName {p.Title} Pics {p.Pics}");
                }
            }
        }

        //02 Albums
        private static void ListPictureInSeveralAlbums(SocialNetworkDbContext db)
        {
            var pictures = db.Pictures
                .Where(p => p.Albums.Count > 2)
                .Select(p => new
                {
                    p.Title,
                    AlbumsTitlesAndOwners = p.Albums.Select(a => new
                    {
                        a.Album.Name,
                        Holders = a.Album.Users//a.Album.AlbumHolders.First(ah => ah.Role == Role.Owner).User.Username //This is not working because of reasons unknown =/
                    })
                })
                .OrderByDescending(p => p.AlbumsTitlesAndOwners.Count())
                .ThenBy(p => p.Title)
                .ToList();

            foreach (var p in pictures)
            {
                Console.WriteLine($"Picture: {p.Title}");
                foreach (var a in p.AlbumsTitlesAndOwners)
                {

                    Console.WriteLine($"--Album name: {a.Name}");
                }
            }
        }

        //03 Albums
        private static void ListAllAlbums(SocialNetworkDbContext db, int id)
        {
            var albums = db.Albums.Where(a => a.Id == id).Select(a => new
            {
                a.Name,
                UserInfo = a.Users.Select(u => new
                {
                    u.User.Username,

                }),
                a.Information,
                a.Pictures

            }).OrderBy(a => a.Name).ToArray();



            foreach (var a in albums)
            {
                Console.WriteLine($"{a.UserInfo}");
                if (a.Information == "public")
                {
                    foreach (var p in a.Pictures)
                    {
                        Console.WriteLine($"Title {p.Picture.Title} Path {p.Picture.Path}");
                    }
                }
                else
                {
                    Console.WriteLine($"{a.Name} => Private content!");
                }

            }
        }


        //01 Shared Albums
        private static void ListUsersSharedAlbums(SocialNetworkDbContext db)
        {
            User currentUser = db.Users.Find(1);

            var sharedAlbums = db.Albums
                .Where(ah =>
                    ah.Users
                        .Any(a => a.User.Username == currentUser.Username && a.Role == Role.Viewer)
                )
                .Select(a => new
                {
                    AlbumName = a.Name,
                    PictureCount = a.Pictures.Count
                })
                .OrderByDescending(a => a.PictureCount)
                .ThenBy(a => a.AlbumName)
                .ToList();

            Console.WriteLine($"Albums shared with: {currentUser}");
            foreach (var alb in sharedAlbums)
            {
                Console.WriteLine($"-Album: {alb.AlbumName}");
                Console.WriteLine($"-Pictures: {alb.PictureCount}");
            }
        }

        //02 Shared Albums
        private static void ListSharedAlbums(SocialNetworkDbContext db)
        {
            var albums = db.Albums
                .Where(a => a.Users.Count(ah => ah.Role == Role.Viewer) > 2)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    SharedCount = a.Users.Count(ah => ah.Role == Role.Viewer),
                    a.Information
                })
                .OrderByDescending(a => a.SharedCount)
                .ThenBy(a => a.AlbumName)
                .ToList();

            foreach (var a in albums)
            {
                Console.WriteLine($"Album: {a.AlbumName}");
                Console.WriteLine($"-Shared with: {a.SharedCount} people");

            }
        }

        //03 Shared Albums
        private static void ListAlbumsSharedWithUser(SocialNetworkDbContext db)
        {
            var testUsername = "Pesho";

            var sharedAlbums = db.Albums
                .Where(ah =>
                    ah.Users
                        .Any(a => a.User.Username == testUsername && a.Role == Role.Viewer)
                )
                .Select(a => new
                {
                    AlbumName = a.Name,
                    PictureCount = a.Pictures.Count
                })
                .OrderByDescending(a => a.PictureCount)
                .ThenBy(a => a.AlbumName)
                .ToList();

            Console.WriteLine($"Albums shared with: {testUsername}");
            foreach (var a in sharedAlbums)
            {
                Console.WriteLine($"-Album: {a.AlbumName}");
                Console.WriteLine($"-Pictures: {a.PictureCount}");
            }
        }

        //01 Roles
        private static void ListUserAlbumInformation(SocialNetworkDbContext db)
        {
            var testUsername = "Gosho";

            var userAlbumInfo = db.Users
                .Where(u => u.Username == testUsername)
                .Select(u => new
                {
                    OwnerOf = u.Albums.Count(ah => ah.Role == Role.Owner),
                    ViewerOf = u.Albums.Count(ah => ah.Role == Role.Viewer)
                })
                .First();

            Console.WriteLine($"User {testUsername} is the owner of {userAlbumInfo.OwnerOf} albums and the viewer of {userAlbumInfo.ViewerOf}.");
        }

        //02 Roles
        private static void ListAllAlbumsWithUser(SocialNetworkDbContext db)
        {
            var albums = db.Albums.
                Select(a => new
                {
                    AlbumName = a.Name,
                    Users = a.Users.Select(ah => new
                    {
                        Username = ah.User.Username,
                        Role = ah.Role
                    }).OrderBy(u => u.Role).ThenBy(u => u.Username)
                })
                .ToList()
                .OrderBy(a => a.Users.First().Username)
                .ThenByDescending(a => a.Users.Count(u => u.Role == Role.Viewer))
                .ToList();

            foreach (var alb in albums)
            {
                Console.WriteLine($"Album: {alb.AlbumName}");
                foreach (var user in alb.Users)
                {
                    Console.WriteLine($"--User: {user.Username}, role = {user.Role}");
                }
            }
        }


        //03 Roles
        private static void ListUsersAndAlbumViewers(SocialNetworkDbContext db)
        {
            var usrs = db.Users
                .Select(u => new
                {
                    u.Username,
                    FollowerIds = u.Firends.Select(f => f.FriendId),
                    AlbumsOwnedIds = u.Albums
                        .Where(a => a.Role == Role.Owner)
                        .Select(a => a.AlbumId)
                })
                .OrderBy(u => u.Username)
                .ToList();

        }


        //00 Tags
        private static void RegisterUserTags(SocialNetworkDbContext db)
        {
            Console.WriteLine("Enter a tag value or leave empty to continue.");

            while (true)
            {
                Console.Write("Title of tag: ");
                string tagValue = Console.ReadLine();

                if (string.IsNullOrEmpty(tagValue) || string.IsNullOrWhiteSpace(tagValue))
                {
                    Console.WriteLine("Continuing..");
                    break;
                }
                else
                {
                    if (!TagValidator.ValidateTag(tagValue))
                    {
                        tagValue = TagTransformer.Transform(tagValue);
                    }

                    if (TagValidator.ValidateTag(tagValue))
                    {
                        var tag = new Tag
                        {
                            Title = tagValue
                        };

                        if (db.Tags.Any(t => t.Title == tagValue))
                        {
                            Console.WriteLine($"Database already contains such a tag: {tagValue}");
                        }
                        else
                        {
                            db.Tags.Add(tag);

                            db.SaveChanges();

                            Console.WriteLine($"Tag: {tagValue} was added to the database.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid tag.");
                    }
                }
            }
        }

        //01 Tags
        private static void ListAlbumByGivenTag(SocialNetworkDbContext db, string tagExample)
        {
            Tag tag = new Tag();

            var albums = db.Albums.Where(a => a.Tags.Any(t => t.Tag == tag)).Select(a => new
            {
                a.Name,
                Users = a.Users.Select(u => new
                {
                    u.User.Username
                }),
                Tags = a.Tags.Count
            }).OrderByDescending(t => t.Tags).ThenBy(a => a.Name).ToArray();

            foreach (var a in albums)
            {
                Console.WriteLine($"{a.Name} Owner {a.Users}");
            }
        }

        //02 Tags
        private static void ListUsersWithMoreThan3Tags(SocialNetworkDbContext db)
        {
            var users = db.Users.Where(u => u.Albums.Any(a => a.Album.Tags.Count > 3)).Select(a => new
            {
                a.Username,
                AlbumInfo = a.Albums.Select(s => new
                {
                    s.Album.Name,
                    Tags = s.Album.Tags.Select(t => t.Tag.Title),
                    TagsCount = s.Album.Tags.Count

                }),
                AlbumCount = a.Albums.Count
            }).OrderByDescending(a => a.AlbumCount)
                .ThenBy(s => s.AlbumInfo.OrderByDescending(f => f.TagsCount))
                .ThenBy(a => a.Username);

            foreach (var u in users)
            {
                Console.WriteLine($"User: {u.Username}");
                foreach (var alb in u.AlbumInfo)
                {
                    Console.WriteLine($"   Album: {alb.Name}");
                    Console.WriteLine($"    Tags: {string.Join(", ", alb.Tags)}");
                }
            }
        }



        private static void SeedSomeData(SocialNetworkDbContext db)
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    Username = "Krivia",
                    Password = "12345689",
                    Email = "gosho@abv.bg",
                    Age = 30,
                    LastTimeLoggedIn = new DateTime(2000,1,3),
                    ProfilePicture = new Picture()
                    {
                        Caption = "best",
                        Path = "c\\:",
                        Title = "Summer"
                    },
                    RegisteredOn = new DateTime(1985,3,12),
                    IsDeleted = false

                },
                  new User()
                {
                    Username = "Pravia",
                    Password = "12345689",
                    Email = "gosho@abv.bg",
                    Age = 25,
                    LastTimeLoggedIn = new DateTime(2009,4,3),
                    ProfilePicture = new Picture()
                    {
                        Caption = "gitina",
                        Path = "c\\:",
                        Title = "Summer"
                    },
                    RegisteredOn = new DateTime(2000,3,9),
                    IsDeleted = false

                },
                new User()
                {
                    Username = "Ugliest",
                    Password = "12345689",
                    Email = "gosho@abv.bg",
                    Age = 25,
                    LastTimeLoggedIn = new DateTime(2005,4,3),
                    ProfilePicture = new Picture()
                    {
                        Caption = "unique",
                        Path = "c\\:",
                        Title = "Summer"
                    },
                    RegisteredOn = new DateTime(2001,3,1),
                    IsDeleted = false

                },
                new User()
                {
                    Username = "Hansom",
                    Password = "12345689",
                    Email = "gosho@abv.bg",
                    Age = 25,
                    LastTimeLoggedIn = new DateTime(2009,4,3),
                    ProfilePicture = new Picture()
                    {
                        Caption = "moq",
                        Path = "c\\:",
                        Title = "Summer"
                    },
                    RegisteredOn = new DateTime(2000,3,9),
                    IsDeleted = false

                },
                new User()
                {
                    Username = "Pepi",
                    Password = "12345689",
                    Email = "gosho@abv.bg",
                    Age = 25,
                    LastTimeLoggedIn = new DateTime(2009,4,3),
                    ProfilePicture = new Picture()
                    {
                        Caption = "fte",
                        Path = "c\\:",
                        Title = "Summer"
                    },
                    RegisteredOn = new DateTime(2000,3,9),
                    IsDeleted = false

                },

            };

            db.Users.AddRange(users);

            db.SaveChanges();

            User user = db.Users.Find(1);
            User user1 = db.Users.Find(2);
            User user2 = db.Users.Find(3);
            User user3 = db.Users.Find(4);
            User user4 = db.Users.Find(5);

            user.Firends.Add(user1);
            user.Firends.Add(user2);
            user.Firends.Add(user3);
            user1.Firends.Add(user);
            user1.Firends.Add(user4);
            user1.Firends.Add(user2);
            user2.Firends.Add(user);
            user2.Firends.Add(user4);
            user2.Firends.Add(user1);
            user3.Firends.Add(user);
            user3.Firends.Add(user2);

            db.SaveChanges();


            List<Picture> pictures = new List<Picture>()
            {

                new Picture()
                {
                    Caption = "a",
                    Path = "c\\:",
                    Title = "Winter"
                },
                new Picture()
                {
                    Caption = "b",
                    Path = "c\\:",
                    Title = "Fall"
                },
                new Picture()
                {
                    Caption = "c",
                    Path = "c\\:",
                    Title = "Aunt"
                },
            };

            db.Pictures.AddRange(pictures);
            db.SaveChanges();


        }

        private static void SetUpDataBase(SocialNetworkDbContext db)
        {
            Console.WriteLine("Loading...");
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            Console.Clear();

        }
    }
}
