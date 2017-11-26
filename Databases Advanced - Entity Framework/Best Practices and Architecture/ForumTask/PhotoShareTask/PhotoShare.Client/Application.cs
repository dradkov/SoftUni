namespace PhotoShare.Client
{
    using System;
    using Core;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using PhotoShare.Services;
    using PhotoShare.Services.Contracts;

    public class Application
    {
        public static void Main()
        {
            //ResetDatabase();

            IServiceProvider service = ConfifureService();

            Engine engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfifureService()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<PhotoShareContext>(option => option.UseSqlServer(ServerConfig.ConnectionString));


            serviceCollection.AddTransient<IDataBaseInitializeServise, DataBaseInitializeService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IAlbumRoleService, AlbumRoleService>();
            serviceCollection.AddTransient<IAlbumService, AlbumService>();
            serviceCollection.AddTransient<IAlbumTagService, AlbumTagService>();
            serviceCollection.AddTransient<IFriendshipService, FriendshipService>();
            serviceCollection.AddTransient<IPictureService, PictureService>();
            serviceCollection.AddTransient<ITagService, TagService>();
            serviceCollection.AddTransient<ITownService, TownService>();


            IServiceProvider serverProvider = serviceCollection.BuildServiceProvider();

            return serverProvider;


        }

        private static void ResetDatabase()
        {
            using (var db = new PhotoShareContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}
