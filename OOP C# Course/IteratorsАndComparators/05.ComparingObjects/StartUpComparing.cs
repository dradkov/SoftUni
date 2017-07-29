namespace _05.ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using _05.ComparingObjects.Models;
    using System.Linq;

    public class StartUpComparing
    {
        public static void Main()
        {

            var listOfPersons = new List<Person>();

            string inputLine;


            while ((inputLine = Console.ReadLine()) != "END")
            {

                var splitLine = inputLine.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                var name = splitLine[0];
                var age = int.Parse(splitLine[1]);
                var town = splitLine[2];

                listOfPersons.Add(new Person(name, age, town));

            }

            var personPosition = int.Parse(Console.ReadLine());

            if (personPosition < 0 || personPosition >= listOfPersons.Count)
            {
                Console.WriteLine("No matches");
                return;
            }


            var person = listOfPersons[personPosition];

            var equels = listOfPersons.Count(p => p.CompareTo(person) == 0);

            var nonEquels = listOfPersons.Count - equels;

            Console.WriteLine($"{equels} {nonEquels} {listOfPersons.Count}");


        }
    }
}
