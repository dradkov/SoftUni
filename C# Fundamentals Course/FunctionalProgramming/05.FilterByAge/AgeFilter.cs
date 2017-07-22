namespace FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AgeFilter
    {
        static void Main()
        {
            int numCommands = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < numCommands; i++)
            {
                var personInfo = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                dict.Add(name, age);

            }

            var condition = Console.ReadLine();
            var searchingAge = int.Parse(Console.ReadLine());
            var print = Console.ReadLine();

         
            if (condition == "older")
            {
                var resultOlder = dict.Where(x => x.Value >= searchingAge);

             
                if (print == "name")
                {
                    foreach (var eachOne in resultOlder)
                    {
                        Console.WriteLine($"{eachOne.Key}");
                    }
                }
                else if(print == "age")
                {
                    foreach (var eachOne in resultOlder)
                    {
                        Console.WriteLine($"{eachOne.Value}");
                    }
                }
                else
                {
                    var splitPrint = print.Split();
                    var name = splitPrint[0];
                    var age = splitPrint[1];


                    foreach (var eachOne in resultOlder)
                    {
                        Console.WriteLine($"{eachOne.Key} - {eachOne.Value}");
                    }
                }
            }
            else
            {
                var resultYounger = dict.Where(x => x.Value < searchingAge);
               
                 if (print == "name")
                {
                    foreach (var eachOne in resultYounger)
                    {
                        Console.WriteLine($"{eachOne.Key}");
                    }
                }
                else if(print == "age")
                {
                    foreach (var eachOne in resultYounger)
                    {
                        Console.WriteLine($"{eachOne.Value}");
                    }
                }
                else
                {
                    var splitPrint = print.Split();
                    var name = splitPrint[0];
                    var age = splitPrint[1];


                    foreach (var eachOne in resultYounger)
                    {
                        Console.WriteLine($"{eachOne.Key} - {eachOne.Value}");
                    }
                }
            }

        }

    }
}
