namespace BankSystem.Client.Core
{
    using System;
    using BankSystem.Client.Contracts;

   public class ConsoleRead : IReader
    {
        public string Readline()
        {
            string input = Console.ReadLine();

            return input;
        }
    }
}
