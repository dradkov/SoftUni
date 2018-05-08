namespace BankSystem.Client.Core
{
    using System;
    using System.Linq;
    using BankSystem.Client.Contracts;
    using StudentSystem.Data;

    public class Engine : IEngine
    {
        public static bool UserIsLogged = false;
        public static int CurrentUserId = -1;
        public static string CurrentUserUsername;
        private BankDbContext db;
        private ICommandInterpreter commandInterpreter;
        private IReader reader;
        private IWriter writer;

        public Engine(BankDbContext db,ICommandInterpreter commandInterpreter,IReader reader,IWriter writer)
        {
            this.db = db;
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer = writer;

        }


        public void Run()
        {

           
            while (true)
            {
                string input = this.reader.Readline();

                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    this.writer.WriteLine("Type exit to terminate the program");               
                }

                if (input.Trim().ToLower()=="exit")
                {
                    Environment.Exit(0);
                }

                string[] tokens = input.Trim().Split();

                string cmdName = null;

                string[] args = null;

               



                cmdName = tokens[0];

                args = tokens.Skip(1).ToArray();

                if (cmdName == "Add" )
                {
                    if (tokens[1] == "SavingsAccount")
                    {
                        cmdName = "AddSavingAccount";
                        args = tokens.Skip(2).ToArray();
                    }
                    else
                    {
                        cmdName = "AddCheckingAccount";

                        args = tokens.Skip(2).ToArray();
                    }
                }

               

                IExecutable command = this.commandInterpreter.InterpretCommand(cmdName, args);


                if (command == null)
                {
                    this.writer.WriteLine(string.Format(ErrorMesseges.InvalidCommand, cmdName));
                 
                }


                string result = command.Execute();

                this.writer.WriteLine(result);
            }
        }
    }
}
