namespace PhotoShare.Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Linq;

    public class TagService : ITagService
    {
        private readonly PhotoShareContext context;

        public TagService(PhotoShareContext context)
        {
            this.context = context;
        }

        public string AddTag(string tagName)
        {
            var tag = context.Tags.SingleOrDefault(t => t.Name == tagName);

            if (tag != null)
            {
                throw new ArgumentException($"Tag {tagName} exists!");
            }

            tag = new Tag
            {
                Name = tagName
            };

            context.Tags.Add(tag);

            context.SaveChanges();

            return $"Tag {tagName} was added successfully!";
        }
    }
}