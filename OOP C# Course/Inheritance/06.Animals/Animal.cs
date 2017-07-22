namespace Animals
{

    using System;
    using System.Linq;

    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                if (value.All(char.IsDigit))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                var temp = value.ToString();
                if (!temp.All(char.IsDigit) || string.IsNullOrEmpty(temp))
                {
                    throw new ArgumentException("Invalid input!");
                }
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }
        public string Gender
        {
            get { return this.gender; }
            set
            {
                if (string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                if (value.All(char.IsDigit))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }
    }
}

