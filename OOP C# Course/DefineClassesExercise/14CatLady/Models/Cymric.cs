namespace CatLady.Models
{
    public class Cymric
    {
        private string breed;
        private string name;
        private decimal furLength;


        public Cymric(string breed, string name, decimal furLength)
        {
            this.Breed = breed;
            this.Name = name;
            this.FurLength = furLength;

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
        public decimal FurLength
        {
            get { return this.furLength; }
            set { this.furLength = value; }
        }
    }
}

