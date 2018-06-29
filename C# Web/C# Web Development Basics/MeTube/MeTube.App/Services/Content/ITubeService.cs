namespace MeTube.App.Services.Content
{
    using System.Collections.Generic;
    using MeTube.App.Models;
    using MeTube.Models;

    public interface ITubeService
    {
        bool Create(string username, string title, string author, string youTubeId, string description);

        Tube TubeExist(int id);

        void IncrementTubeViews(int id);

        List<AllTubeViewModel> All();

        List<ProfileTubeModel> ProfileTubes(int userId);

    }
}
