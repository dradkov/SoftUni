namespace UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LogsUser
    {
        static void Main()
        {
            var dictionaryInfo = new Dictionary<string, Dictionary<string, int>>();

            var data = Console.ReadLine().Trim();

            var count = 1;

            while (data != "end")
            {
                var dataSplit = data.Split(new[] { ' ','=', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                var IP = dataSplit[1];
                var userName = dataSplit[5];

                if (!dictionaryInfo.ContainsKey(userName))
                {
                    dictionaryInfo.Add(userName, new Dictionary<string, int>());
                }
                if (!dictionaryInfo[userName].ContainsKey(IP))
                {
                    dictionaryInfo[userName].Add(IP, 0);
                }             
                dictionaryInfo[userName][IP] += count;



                data = Console.ReadLine();
            }
            Print(dictionaryInfo);

        }

        public static void Print(Dictionary<string, Dictionary<string, int>> dictionaryInfo)
        {
            foreach (var userInfo in dictionaryInfo.OrderBy(u =>u.Key))
            {
                Console.WriteLine($"{userInfo.Key}:");
                foreach (var IP in userInfo.Value)
                {
                    if (IP.Key != userInfo.Value.Keys.Last())//  check for num of IP-s 
                    {

                        Console.Write($"{IP.Key} => {IP.Value}, "); //reason comma
                    }
                    else
                    {
                        Console.WriteLine($"{IP.Key} => {IP.Value}.");
                    }
                }
            }
        }
    }
}
