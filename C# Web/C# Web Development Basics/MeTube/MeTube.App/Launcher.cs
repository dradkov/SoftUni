namespace MeTube.App
{
    using MeTube.Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Luncher
    {
       public static void Main()
        {
            var server = new WebServer(
                1337,
                new ControllerRouter(),
                new ResourceRouter());
            var dbContext = new MeTubeDbContext();

            MvcEngine.Run(server, dbContext);
        }
    }
}
