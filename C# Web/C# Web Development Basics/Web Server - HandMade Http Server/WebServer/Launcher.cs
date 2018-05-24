namespace WebServer
{
    using Application;
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
            MainApplication mainApplication = new MainApplication();
            AppRouteConfig appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            WebServer webServer = new WebServer(Port, appRouteConfig);
            webServer.Run();
        }
    }
}