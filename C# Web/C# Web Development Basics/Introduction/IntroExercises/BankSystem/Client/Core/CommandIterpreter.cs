namespace BankSystem.Client.Core
{
    using System;
    using BankSystem.Client.Contracts;
    using StudentSystem.Data;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string NameSpacePath = @"BankSystem.Client.Core.Commands.{0}Command";

        private BankDbContext db;

        public CommandInterpreter(BankDbContext db)
        {
            this.db = db;
        }

        public IExecutable InterpretCommand(string commandName, string[] arguments)
        {
            IExecutable command = null;

            string typeName = string.Format(NameSpacePath, commandName);

            Type classType = Type.GetType(typeName);

            if (classType != null)
            {
                command = (IExecutable)Activator.CreateInstance(classType, new object[] { this.db, arguments });
            }

            return command;
        }
    }
}
