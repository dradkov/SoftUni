namespace _01.ListyIterator
{
    using System;
    using System.Linq;
    using _01.ListyIterator.Models;

    public class StartUpListyIterator
    {
      
        public static void Main()
        {

            ListyIterator listy = null;

            string inputInfo;

            while ((inputInfo = Console.ReadLine()) != "END")
            {
                var split = inputInfo.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (split[0])
                    {
                        case "Create":

                            listy = new ListyIterator(split.Skip(1).ToArray());
                            break;

                        case "Move":
                            Console.WriteLine(listy.Move());

                            break;
                        case "HasNext":
                            Console.WriteLine(listy.HasNext());

                            break;
                        case "Print":
                           listy.Print();
                            break;
                        case "PrintAll":
                                listy.PrintAll();
                                break;

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Operation!");

                }


            }
        }
    }
}
