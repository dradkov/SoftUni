using System;
using System.Collections.Generic;
using _07.EqualityLogic.Models;

namespace _07.EqualityLogic
{
    public class StartUpLogic
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> sortedPeopleBySortedSet = new SortedSet<Person>();
            HashSet<Person> sortedPeopleByHashSet = new HashSet<Person>();

            var numCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCommands; i++)
            {

                var splitCommand = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                var name = splitCommand[0];
                var age = int.Parse(splitCommand[1]);

                sortedPeopleBySortedSet.Add(new Person(name, age));
                sortedPeopleByHashSet.Add(new Person(name, age));

            }
            Console.WriteLine(sortedPeopleBySortedSet.Count);
            Console.WriteLine(sortedPeopleByHashSet.Count);
        }
    }
}
