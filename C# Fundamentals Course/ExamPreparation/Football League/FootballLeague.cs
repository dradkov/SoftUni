namespace FootballLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FootballLeague
    {
        static void Main(string[] args)
        {
            var ligaStandings = new Dictionary<string, int>();
            var topScoreListed = new Dictionary<string, int>();

            var key = Console.ReadLine();
            var command = Console.ReadLine();


            while (!command.Equals("final"))
            {
                var commandInfo = command.Split(); /*<- Posible remove Empty spaces*/

                var firstTeamName = GetTeamName(commandInfo[0], key);
                var secondTeamName = GetTeamName(commandInfo[1], key);

                var resultSplit = commandInfo[2].Split(':');

                var firstTeamGoals = int.Parse(resultSplit[0]);
                var secondTeamGoals = int.Parse(resultSplit[1]);


                if (firstTeamGoals > secondTeamGoals)
                {
                    AddScore(ligaStandings, firstTeamName, 3);
                    AddScore(ligaStandings, secondTeamName, 0);
                }
                else if (firstTeamGoals < secondTeamGoals)
                {
                    AddScore(ligaStandings, firstTeamName, 0);
                    AddScore(ligaStandings, secondTeamName, 3);
                }
                else
                {
                    AddScore(ligaStandings, firstTeamName, 1);
                    AddScore(ligaStandings, secondTeamName, 1);
                }

                AddScore(topScoreListed, firstTeamName, firstTeamGoals);
                AddScore(topScoreListed, secondTeamName, secondTeamGoals);



                command = Console.ReadLine();
            }

            Console.WriteLine("League standings:");
            var sorted = ligaStandings.OrderByDescending(t => t.Value).ThenBy(t => t.Key);
            int count = 1;
            foreach (var team in sorted)
            {
                Console.WriteLine($"{count}. {team.Key} {team.Value}");
                count++;
            }

            Console.WriteLine("Top 3 scored goals:");
            var sortedGoals = topScoreListed.OrderByDescending(t => t.Value).ThenBy(t => t.Key).Take(3);
            foreach (var team in sortedGoals)
            {
                Console.WriteLine($"- {team.Key} -> {team.Value}");
                count++;
            }

        }

        private static void AddScore(Dictionary<string, int> ligaStandings, string firstTeamName, int firstTeamGoals)
        {
            if (!ligaStandings.ContainsKey(firstTeamName))
            {
                ligaStandings.Add(firstTeamName, 0);
            }
            ligaStandings[firstTeamName] += firstTeamGoals;
        }

        private static string GetTeamName(string TeamName, string key)
        {
            var startIndex = TeamName.IndexOf(key) + key.Length;
            var lastIndex = TeamName.LastIndexOf(key);
            var length = lastIndex - startIndex;

            var name = TeamName.Substring(startIndex, length).ToUpper();

            var reversedName = name.Reverse();

            return string.Join("", reversedName);
        }
    }
}
