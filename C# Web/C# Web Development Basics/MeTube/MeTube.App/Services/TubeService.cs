namespace MeTube.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using MeTube.App.Models;
    using MeTube.App.Services.Content;
    using MeTube.Data;
    using MeTube.Models;

    public class TubeService : ITubeService

    {
        public bool Create(string username, string title, string author, string youTubeId, string description)
        {
            using (MeTubeDbContext db = new MeTubeDbContext())
            {
                Tube tube = new Tube
                {

                    Title = title,
                    Author = author,
                    YouTubeVideo = youTubeId,
                    Description = description
                };

                User user = db.Users.FirstOrDefault(u => u.Username == username);

                db.Tubes.Add(tube);

                if (user != null)
                {
                    user.Tubes.Add(tube);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Tube TubeExist(int id)
        {
            using (MeTubeDbContext db = new MeTubeDbContext())
            {
                Tube tube = db.Tubes.Find(id);

                return tube;
            }
        }

        public void IncrementTubeViews(int id)
        {
            using (MeTubeDbContext db = new MeTubeDbContext())
            {
                Tube tube = db.Tubes.Find(id);

                tube.Views++;
                db.SaveChanges();
            }
        }

        public List<AllTubeViewModel> All()
        {
            using (MeTubeDbContext db = new MeTubeDbContext())
            {
                return db.Tubes
                    .Select(t => new AllTubeViewModel
                    {
                        Title = t.Title,
                        Author = t.Author,
                        YouTubeId = t.YouTubeVideo
                    })
                    .ToList();
            }
        }

        public List<ProfileTubeModel> ProfileTubes(int userId)
        {
            using (MeTubeDbContext db = new MeTubeDbContext())
            {
                return db.Tubes
                    .Where(t => t.UserId == userId)
                    .Select(t => new ProfileTubeModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Author = t.Author,
                        YouTubeId = t.YouTubeVideo
                    })
                    .ToList();
            }
        }
    }
}
