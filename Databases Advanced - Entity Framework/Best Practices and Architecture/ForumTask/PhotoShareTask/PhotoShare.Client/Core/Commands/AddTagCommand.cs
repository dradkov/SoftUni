namespace PhotoShare.Client.Core.Commands
{
    using Utilities;
    using PhotoShare.Services.Contracts;
    using System;
    using PhotoShare.Client.Core.Contracts;

    public class AddTagCommand : ICommand
    {
        private readonly ITagService tagService;

        public AddTagCommand(ITagService tagService)
        {
            this.tagService = tagService;
        }

        // AddTag <tag>
        public string Execute(string command, string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 1)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string tag = data[0].ValidateOrTransform();

            return tagService.AddTag(tag);
        }
    }
}