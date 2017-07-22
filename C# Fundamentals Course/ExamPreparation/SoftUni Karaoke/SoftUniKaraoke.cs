namespace SoftUniKaraoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SoftUniKaraoke
    {
        static void Main(string[] args)
        {
            var dictAwards = new Dictionary<string, List<string>>();
                                                           
            var nameParticipants = Console.ReadLine().Split(',').Select(n => n.Trim()).ToArray();
            var avalibleSongs = Console.ReadLine().Split(',').Select(n => n.Trim()).ToArray();

            var nameSongAwards = Console.ReadLine();

            while (!nameSongAwards.Equals("dawn"))
            {

                var nameSongAwInfo= nameSongAwards.Split(',').Select(n => n.Trim()).ToArray();

                var name = nameSongAwInfo[0];
                var song = nameSongAwInfo[1];
                var award = nameSongAwInfo[2];


                if (nameParticipants.Contains(name)&& avalibleSongs.Contains(song))
                {
                    if (!dictAwards.ContainsKey(name))
                    {
                        dictAwards.Add(name, new List<string>());
                    }
                    if (!dictAwards[name].Contains(award))
                    {
                        dictAwards[name].Add(award);
                    }
                   
                }
               
                nameSongAwards = Console.ReadLine();
            }

            var sorted = dictAwards.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);
            if (sorted.Any())
            {
                foreach (var participant in sorted)
                {
                    Console.WriteLine($"{participant.Key}: {participant.Value.Count} awards");

                    foreach (var item in participant.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"--{item}");
                    }

                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
           

        }
    }
}
