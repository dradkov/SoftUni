namespace OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartIp
    {
        static void Main(string[] args)
        {
            var numLines = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < numLines; i++)
            {
                var split = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);


                people.Add(new Person(split[0], int.Parse(split[1])));
            }

            var result = people.Where(p => p.Age > 30).OrderBy(x => x.Name).ToList();

            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}

