namespace Kittens.App
{
    using Kittens.Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
       public static void Main(string[] args)
        {
            var server = new WebServer(
                1337,
                new ControllerRouter(),
                new ResourceRouter());
            var dbContext = new KittenDbContext();

            MvcEngine.Run(server, dbContext);
        }
    }
}
