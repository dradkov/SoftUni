namespace PhotoShare.Client.Core.Commands
{
    
    using PhotoShare.Services.Contracts;
    using System;
    using PhotoShare.Client.Core.Contracts;

    public class AddTownCommand : ICommand
    {
        private readonly ITownService townService;

        public AddTownCommand(ITownService townService)
        {
            this.townService = townService;
        }

        // AddTown <townName> <countryName>
        public string Execute(string command, string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string townName = data[0];
            string countryName = data[1];

            return townService.AddTown(townName, countryName);
        }
    }
}