namespace Avatar.Models.Monuments
{

    using Avatar.Interfaces;

    public abstract class Monument : IMonument
    {

        private string name;

        public Monument(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            protected set => this.name = value;
        }
    }
}
