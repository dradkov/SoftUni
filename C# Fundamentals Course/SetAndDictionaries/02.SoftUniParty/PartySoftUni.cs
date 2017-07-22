namespace SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PartySoftUni

    {
        static void Main()
        {
            var guestName = Console.ReadLine();


            var guestsList = new SortedSet<string>();

            while (guestName != "END")
            {
                if (guestName.Length == 8)
                {
                    guestsList.Add(guestName);
                }
                if (guestName == "PARTY")
                {
                    while (guestName != "END")
                    {
                        if (guestsList.Contains(guestName))
                        {
                            guestsList.Remove(guestName);
                            
                        }
                        guestName = Console.ReadLine();
                       
                    }
                }
                if (guestName == "END")
                {
                    break;
                }
             

                guestName = Console.ReadLine();
            }


            Console.WriteLine(guestsList.Count());

            foreach (var guest in guestsList)
            {
                Console.WriteLine(guest);
            }

        }
    }
}
