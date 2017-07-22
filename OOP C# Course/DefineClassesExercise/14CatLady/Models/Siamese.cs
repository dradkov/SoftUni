namespace CatLady.Models
{
    public class Siamese
    {
        private string breed;
        private string name;
        private long earSize;


        public Siamese(string breed, string name, long earSize)
        {
            this.Breed = breed;
            this.Name = name;
            this.EarSize = earSize;

        }


        public string Breed
        {
            get { return this.breed; }
            set { this.breed = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public long EarSize
        {
            get { return this.earSize; }
            set { this.earSize = value; }
        }
    }
}

