using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Employee.Client.Contracts;

namespace Employee.Client.Core
{
    public class Engine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                string[] splitInput = input.Split();

                string commandName = splitInput[0];

                string[] commandArgs = splitInput.Skip(1).ToArray();

                ICommand command = CommandParser.Parse(serviceProvider, commandName);

                var result = command.Execute(commandArgs);

                Console.WriteLine(result);
            }
        }
    }
}
