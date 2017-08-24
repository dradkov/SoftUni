namespace ChampionsLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {

        public static void Main(string[] args)
        {

            var listTeams = new List<Team>();

            Team team = null;

            int numberOfWins = 1;

            string input;


            while ((input = Console.ReadLine()) != "stop")
            {
                string[] split = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                string[] firstMachResultSplit = split[2].Split(':');
                string[] secondMachResultSplit = split[3].Split(':');

                string firstTeamName = split[0].Trim();
                string secondTeamName = split[1].Trim();

                int goalFirstMatchFirstTeam = int.Parse(firstMachResultSplit[0]);
                int goalFirstMatchSecondTeam = int.Parse(firstMachResultSplit[1]);

                int goalSecondMatchSecondTeam = int.Parse(secondMachResultSplit[0]);
                int goalSecondMatchFirstTeam = int.Parse(secondMachResultSplit[1]);

                string winner = CheckForWinner(firstTeamName, secondTeamName, goalFirstMatchFirstTeam,
                    goalFirstMatchSecondTeam, goalSecondMatchFirstTeam, goalSecondMatchSecondTeam);

                string loser = FindLoser(winner, firstTeamName, secondTeamName);


                if (!listTeams.Any(x => x.TeamName == winner && !x.Opponents.Contains(loser)))
                {
                    team = new Team(winner, numberOfWins);
                    team.Opponents.Add(loser);
                    listTeams.Add(team);
                }
                if (!listTeams.Any(x => x.TeamName == loser && !x.Opponents.Contains(winner)))
                {

                    team = new Team(loser, 0);
                    team.Opponents.Add(winner);
                    listTeams.Add(team);
                }
                if (listTeams.Any(x => x.TeamName == loser && !x.Opponents.Contains(winner)))
                {
                   team = listTeams.First(x => x.TeamName == loser);

                    team.Opponents.Add(winner);
                    team.Wins += 0;
                }
                if (listTeams.Any(x => x.TeamName == winner && !x.Opponents.Contains(loser)))
                {
                    team = listTeams.First(x => x.TeamName == winner);

                    team.Opponents.Add(loser);
                    team.Wins += numberOfWins;
                }
            }

            Print(listTeams);
        }

        private static void Print(IEnumerable<Team> listTeams)
        {
            IList<Team> result = listTeams.OrderByDescending(x => x.Wins).ThenBy(x => x.TeamName).ToList();

            foreach (var team in result)
            {

                Console.WriteLine(team);
            }

        }

        private static string FindLoser(string winner, string firstTeamName, string secondTeamName)
        {
            if (winner == firstTeamName)
            {
                return secondTeamName;
            }
            else
            {
                return firstTeamName;
            }
        }

        private static string CheckForWinner(string firstTeamName, string secondTeamName,
            int goalFirstMatchFirstTeam, int goalFirstMatchSecondTeam, int goalSecondMatchFirstTeam,
            int goalSecondMatchSecondTeam)
        {
            int totalGoalsFirstTeam = goalFirstMatchFirstTeam + goalSecondMatchFirstTeam;

            int totalGoalsSecondTeam = goalFirstMatchSecondTeam + goalSecondMatchSecondTeam;

            if (totalGoalsFirstTeam == totalGoalsSecondTeam)
            {
                if (goalSecondMatchFirstTeam > goalFirstMatchSecondTeam)
                {
                    return firstTeamName;
                }
                else
                {
                    return secondTeamName;
                }
            }
            else if (totalGoalsFirstTeam > totalGoalsSecondTeam)
            {
                return firstTeamName;
            }
            else
            {
                return secondTeamName;
            }
        }
    }
}

