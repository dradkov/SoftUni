using System;
using System.Reflection;
using Employee.Client.Contracts;

namespace Employee.Client.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(params string[] args)
        {

            Console.WriteLine("Game Over");
            Environment.Exit(0);

            return "";
        }
    }
}
