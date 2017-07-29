namespace _07.EqualityLogic.Models
{
    using System;
    using System.Linq;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
           this.Name = name;
           this.Age = age;
        }



        public string  Name { get; private set; }
        public int  Age { get; private set; }


        public override bool Equals(object other)
        {
            var person = other as Person;
            return this.Name == person.Name && this.Age == person.Age;

        }


        public override int GetHashCode()
        {
            var hashCode = this.Name.Length * 10000;
            hashCode = this.Name.Aggregate(hashCode, (current, letter) => current + letter);
            hashCode += this.Age * 10000; 

            return hashCode;
        }


        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age - other.Age;
            }
            return result;
        }
    }
}
