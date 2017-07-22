namespace NetherRealms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class NetherRealms
    {
        static void Main(string[] args)

        {

            var demonsInfo = Console.ReadLine().Split(new[] { ' ', ',' }
            , StringSplitOptions.RemoveEmptyEntries).ToArray();

            var dictDemons = new Dictionary<string, Demons>();

            foreach (var demon in demonsInfo)
            {

                var regex = new Regex(@"(\-|\+)*([0-9]+\.)*[0-9]+");
                var matches = regex.Matches(demon);

                double sumDamage = 0;

                foreach (var match in matches)
                {
                    var num = double.Parse(match.ToString());
                    sumDamage += num;
                }

                var regexDev = new Regex(@"\/");
                var matchesDev = regexDev.Matches(demon);

                foreach (var match in matchesDev)
                {
                    sumDamage /= 2;
                }

                var regexMulty = new Regex(@"\*");
                var matchesMulty = regexMulty.Matches(demon);

                foreach (var match in matchesMulty)
                {
                    sumDamage *= 2;
                }

                var sumHealth = 0;

                var regexLetter = new Regex(@"[^\d\+\-\*\.\/]+");
                var matchLetter = regexLetter.Matches(demon);

                foreach (var match in matchLetter)
                {
                    var symbol = match.ToString().ToCharArray();

                    foreach (var ch in symbol)
                    {
                        sumHealth += (int)ch;
                    }

                }
                var demonClass = new Demons { Damage = sumDamage, Health = sumHealth };

                dictDemons.Add(demon, demonClass);          
            }
            foreach (var demonPrint in dictDemons.OrderBy(d => d.Key))
            {
                Console.WriteLine($"{demonPrint.Key} - {demonPrint.Value.Health} health, {demonPrint.Value.Damage:f2} damage");
            }
        }
    }
    class Demons
    {
        public double Damage { get; set; }
        public double Health { get; set; }
    }
}
