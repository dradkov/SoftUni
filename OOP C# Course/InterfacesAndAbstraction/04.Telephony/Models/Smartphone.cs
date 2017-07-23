namespace Phone
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Smartphone : ICallable, IBrowsable
    {

        public void Browsing(IEnumerable<string> ipAddress)
        {
            var regex = new Regex(@"\d+");

            foreach (var ip in ipAddress)
            {
                var match = regex.Match(ip);
                if (match.Success)
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine($"Browsing: {ip}!");
                }

            }
        }

        public void Calling(IEnumerable<string> phoneNums)
        {
            var regex = new Regex(@"\D+");

            foreach (var number in phoneNums)
            {
                var match = regex.Match(number);

                if (!match.Success)
                {
                    Console.WriteLine($"Calling... {number}");
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }

            }
        }
    }
}

