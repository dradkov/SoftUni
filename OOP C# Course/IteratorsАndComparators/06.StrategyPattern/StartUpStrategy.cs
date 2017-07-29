using System;
using System.Collections.Generic;
using _06.StrategyPattern.Models;

namespace _06.StrategyPattern
{
     public class StartUpStrategy
    {
        static void Main(string[] args)
        {
            SortedSet<Person> peopleByName = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> peopleByAge = new SortedSet<Person>(new AgeComparator());


            var numCommands = int.Parse(Console.ReadLine());


            for (int i = 0; i < numCommands; i++)
            {
                var lineInfo  = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                var name = lineInfo[0];
                var age = int.Parse(lineInfo[1]);

                peopleByName.Add(new Person(name, age));
                peopleByAge.Add(new Person(name, age));

            }


            foreach (var person in peopleByName)
            {
                Console.WriteLine(person);
            }
            foreach (var person in peopleByAge)
            {
                Console.WriteLine(person);
            }

        }
    }
}
