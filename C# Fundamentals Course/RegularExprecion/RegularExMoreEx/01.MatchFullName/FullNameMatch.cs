namespace MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class FullNameMatch
    {
        static void Main()
        {
            var names = Console.ReadLine();


            while (names != "end")
            {
               
 
                var regex = new Regex(@"[A-Z]{1}[a-z]+\s[A-Z][a-z]+");

                var match = regex.Matches(names);
               

                foreach (Match item in match)
                {
                    Console.WriteLine(string.Join(" ",item));
                }
                names = Console.ReadLine();
            }
        }
    }
}
