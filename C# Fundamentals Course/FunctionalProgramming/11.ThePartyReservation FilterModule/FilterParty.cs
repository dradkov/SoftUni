namespace ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterParty
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var commands = Console.ReadLine();

            var startCase = new List<string>();
            var endCase = new List<string>();
            var containsCase = new List<string>();
            var lenCase = new List<int>();

            while (commands != "Print")
            {
                var splitCommand = commands.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                var comm = splitCommand[0];
                var type = splitCommand[1];
                var parameter = splitCommand[2];
                if (comm == "Add filter")
                {
                    switch (type)
                    {
                        case "Starts with": startCase.Add(parameter); break;
                        case "Ends with": endCase.Add(parameter); break;
                        case "Contains": containsCase.Add(parameter); break;
                        case "Length": lenCase.Add(int.Parse(parameter)); break;
                        default:
                            break;
                    }
                }
                else if (comm == "Remove filter")
                {
                    switch (type)
                    {
                        case "Starts with": startCase.Remove(parameter); break;
                        case "Ends with": endCase.Remove(parameter); break;
                        case "Contains": containsCase.Remove(parameter); break;
                        case "Length": lenCase.Remove(int.Parse(parameter)); break;
                        default:
                            break;
                    }
                }


                commands = Console.ReadLine();
            }

            foreach (var word in startCase)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].StartsWith(word))
                    {
                        people.Remove(people[i]);
                        i--;
                    }
                }
            }
            foreach (var word in endCase)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].EndsWith(word))
                    {
                        people.Remove(people[i]);
                        i--;
                    }
                }
            }
            foreach (var word in containsCase)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Contains(word))
                    {
                        people.Remove(people[i]);
                        i--;
                    }
                }
            }
            foreach (var num in lenCase)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Length <= num)
                    {
                        people.Remove(people[i]);
                        i--;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }
    }
}
