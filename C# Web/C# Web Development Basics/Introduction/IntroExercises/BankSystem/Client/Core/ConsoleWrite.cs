namespace BankSystem.Client.Core
{
    using System;
    using BankSystem.Client.Contracts;

    public class ConsoleWrite : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
