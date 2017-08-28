namespace NumberWars
{
    public class Card
    {
        public Card(int digit, string name)
        {
            this.Digit = digit;
            this.Name = name;
        }

        public int Digit { get; set; }
        public string Name { get; set; }
    }
}
