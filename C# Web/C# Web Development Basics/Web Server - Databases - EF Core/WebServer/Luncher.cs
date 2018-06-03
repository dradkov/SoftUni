namespace WebServer
{
    using ByTheCakeApplication;
    using Server;
    using Server.Contracts;
    using Server.Routing;
   

    public class Launcher : IRunnable
    {
        private const int Port = 1337;

        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {

            ByTheCakeApp mainApplication = new ByTheCakeApp();
            mainApplication.InitializeDatabase();

            AppRouteConfig appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            WebServer webServer = new WebServer(Port, appRouteConfig);
            webServer.Run();
        }
    }
}