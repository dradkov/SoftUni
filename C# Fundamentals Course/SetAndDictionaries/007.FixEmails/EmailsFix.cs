namespace FixEmails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EmailsFix
    {
        static void Main()
        {
            var emailsInfo = new Dictionary<string, string>();

            var name = Console.ReadLine();

            while (name != "stop")
            {
                var email = Console.ReadLine();
                var domain = email.Substring(email.Length - 2);

                if (domain != "uk" && domain != "us")
                {
                    if (!emailsInfo.ContainsKey(name))
                    {
                        emailsInfo.Add(name, "");
                    }
                    emailsInfo[name] = email;
                }
                else
                {
                    break;
                }
                name = Console.ReadLine();
            }

            foreach (var person in emailsInfo)
            {
                Console.WriteLine($"{person.Key} -> {person.Value}");
            }
        }
    }
}
