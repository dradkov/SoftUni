namespace Phonebook
{
    using System;
    using System.Collections.Generic;

    class BookPhone
    {
        static void Main()
        {
            var phoneBook = new Dictionary<string, string>();

            var contactInput = Console.ReadLine();
            var setNames = new HashSet<string>();


            while (contactInput != "search")
            {
                var contactInfo = contactInput
                    .Split(new[] { ' ', '-', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);


                var name = contactInfo[0];
                var phoneNumber = contactInfo[1];


                if (!phoneBook.ContainsKey(name))
                {
                    phoneBook.Add(name, string.Empty);
                }
                phoneBook[name] = phoneNumber;

                contactInput = Console.ReadLine();

            }
            contactInput = Console.ReadLine();

            while (contactInput!="stop")
            {
                if (contactInput=="search")
                {
                    break;
                }
                else
                {
                    if (phoneBook.ContainsKey(contactInput))
                    {
                        Console.WriteLine($"{contactInput} -> {phoneBook[contactInput]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {contactInput} does not exist.");
                    }
                }
                contactInput = Console.ReadLine();
            }

        }
    }

}

