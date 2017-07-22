namespace LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class AgregatorLog
    {
        static void Main()
        {

            var dict = new Dictionary<string, Dictionary<string,int >>();

            var commands = int.Parse(Console.ReadLine());


            for (int i = 0; i < commands; i++)
            {
                var info = Console.ReadLine().Split();

                var IP = info[0];
                var userName = info[1];
                var duration = int.Parse(info[2]);

                if (!dict.ContainsKey(userName))
                {
                    dict.Add(userName, new Dictionary<string,int>());
                }
                if (!dict[userName].ContainsKey(IP))
                {
                    dict[userName].Add(IP, 0);
                }
                dict[userName][IP] += duration;  

            }

            foreach (var info in dict.OrderBy(inf =>inf.Key))
            {
                var name = info.Key;
                var ip = info.Value.Keys.OrderBy(i=>i).ToList();
                var duration = info.Value.Values.Sum();

                Console.WriteLine($"{name}: {duration} [{string.Join(", ",ip)}]");
             
            }
        }
    }
}
