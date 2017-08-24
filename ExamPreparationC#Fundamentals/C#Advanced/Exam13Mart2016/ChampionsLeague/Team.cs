namespace ChampionsLeague
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Team
    {
        public Team(string teamName, int wins)
        {
            this.TeamName = teamName;
            this.Wins = wins;
            this.Opponents = new List<string>();
        }


        public string TeamName { get; }

        public int Wins { get; set; }


        public List<string> Opponents { get; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.TeamName}");
            sb.AppendLine($"- Wins: {this.Wins}");
            sb.AppendLine($"- Opponents: {string.Join(", ", this.Opponents.OrderBy(x => x))}");

            return sb.ToString().Trim();
        }
    }
}