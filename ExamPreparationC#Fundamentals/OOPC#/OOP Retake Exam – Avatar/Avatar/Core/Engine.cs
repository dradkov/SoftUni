namespace Avatar.Core
{

    using System;
    using System.Linq;
    using Avatar.Interfaces;

    public class Engine : IEngine
    {

        private NationsBuilder nation;

        public Engine()
        {
            this.nation = new NationsBuilder();
        }


        public void Run()
        {
            string commandLine;

            while ((commandLine = Console.ReadLine()) != "Quit")
            {
                string[] command = commandLine.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                switch (command[0].Trim())
                {
                    case "Bender": nation.AssignBender(command.Skip(1).ToList()); break;
                    case "Monument": nation.AssignMonument(command.Skip(1).ToList()); break;
                    case "Status": Console.WriteLine(nation.GetStatus(command[1].Trim())); break;
                    case "War": nation.IssueWar(command[1].Trim()); break;

                }

            }

            Console.WriteLine(nation.GetWarsRecord());

        }
    }
}