namespace SimpleMvc.Framework
{
    using System;
    using WebServer;
    using System.Reflection;

    public static class MvcEngine
    {
        public static void Run(WebServer server)
        {
            RegisterAssamblyName();
            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RegisterAssamblyName()
        {
            MvcContext.Get.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
        }
    }
}
