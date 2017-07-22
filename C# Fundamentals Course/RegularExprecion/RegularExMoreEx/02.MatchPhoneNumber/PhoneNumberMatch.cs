namespace MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class PhoneNumberMatch
    {
        static void Main()
        {
            var phoneList = Console.ReadLine();

            while (phoneList != "end")
            {
                var regex = new Regex(@"\+359( |-).( |-)\d+(-| )\d{4}\b");

                var matches = regex.Matches(phoneList);

                foreach (Match phone in matches)
                {
                    Console.WriteLine(string.Join(" ", phone));
                }



                phoneList = Console.ReadLine();
            }
        }
    }
}