using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             
            Ani Math 80
            Gosho Math 10
            Pesho History 100
            Gosho Geography 90
            END
             
             */

            Dictionary<string, HashSet<string>> categoryData = new Dictionary<string, HashSet<string>>();
            Dictionary<string, int> scoreData = new Dictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Trim().Split();

                string name = tokens[0];
                string category = tokens[1];
                int score = int.Parse(tokens[2]);


                if (!categoryData.ContainsKey(name))
                {
                    categoryData[name] = new HashSet<string>();
                }

                if (!scoreData.ContainsKey(name))
                {
                    scoreData[name] = 0;
                }

                categoryData[name].Add(category);
                scoreData[name] += score;
            }


            var orderScore = scoreData.OrderByDescending(c => c.Value).ThenBy(x => x.Key);


            foreach (var sc in orderScore)
            {
                var data = categoryData[sc.Key].OrderBy(c => c).ToList();

                Console.WriteLine($"{sc.Key}: {sc.Value} [{string.Join(", ", data)}]");
            }
        }
    }
}
