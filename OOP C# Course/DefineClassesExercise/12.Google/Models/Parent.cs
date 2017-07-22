namespace Google.Models
{
    public class Parent
    {
        public string name;
        public string birthday;

        public Parent(string name, string birthday)
        {
            this.name = name;
            this.birthday = birthday;
        }

        public override string ToString()
        {
            return this.name + " " + this.birthday;
        }
    }
}