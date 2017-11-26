namespace PhotoShare.Client.Core
{
    using System;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Services.Contracts;

    public class Engine
    {
      
        private readonly IServiceProvider serviceProvider;

        public Engine( IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var databaseInitializerService = serviceProvider.GetService<IDataBaseInitializeServise>();
            databaseInitializerService.InitializeDatabase();
          

            while (true)
            {

                Console.Write("Enter command: ");
                var input = Console.ReadLine();

                var commandTokens = input.Split(' ');

                var commandArgs = commandTokens.Skip(1).ToArray();

                try
                {
                    ICommand command = CommandParser.ParseCommand(this.serviceProvider, commandTokens.First());

                    var result = command.Execute(commandTokens.First(), commandArgs);

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
