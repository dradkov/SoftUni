namespace CatLady.Models
{
    public class StreetExtraordinaire
    {
        private string breed;
        private string name;
        private long decibels;


        public StreetExtraordinaire(string breed, string name, long decibels)
        {
            this.Breed = breed;
            this.Name = name;
            this.Decibels = decibels;

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
        public long Decibels
        {
            get { return this.decibels; }
            set { this.decibels = value; }
        }
    }
}
