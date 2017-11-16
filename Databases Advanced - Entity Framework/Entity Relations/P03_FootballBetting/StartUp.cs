using System;

namespace P03_FootballBetting
{
    using P03_FootballBetting.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new FootballBettingContext();
        }
    }
}
