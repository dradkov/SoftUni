namespace Minedraft.Core
{

    using System;
    using System.Linq;
    using Minedraft.Interfaces;

    public class Engine : IEngine
    {
        private DraftManager manager;


        public Engine()
        {
            this.manager = new DraftManager();
        }


        public void Run()
        {

            string commandLine;

            while ((commandLine = Console.ReadLine()) != "Shutdown")
            {
                string[] command = commandLine.Trim().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "RegisterHarvester": Console.WriteLine(manager.RegisterHarvester(command.Skip(1).ToList())); break;
                    case "RegisterProvider": Console.WriteLine(manager.RegisterProvider(command.Skip(1).ToList())); break;
                    case "Day": Console.WriteLine(manager.Day()); break;
                    case "Check": Console.WriteLine(manager.Check(command.Skip(1).ToList())); break;
                    case "Mode": Console.WriteLine(manager.Mode(command.Skip(1).ToList())); break;

                }
            }

            Console.WriteLine(manager.ShutDown());

        }
    }
}
