namespace Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Files
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var inputData = new Dictionary<string, Dictionary<string, long>>();
            var fileData = new Dictionary<string, long>();


            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split('\\');
                var fileAndSize = input[input.Length - 1];
                var fileInfo = fileAndSize.Split(';');
                var root = input[0];
                var fileName = fileInfo[0];
                long fileSize = long.Parse(fileInfo[1]);


                if (!inputData.ContainsKey(root))
                {
                    fileData = new Dictionary<string, long>();

                    fileData[fileName] = fileSize;
                    inputData[root] = fileData;
                }
                else
                {
                    inputData[root][fileName] = fileSize;
                }
            }

            var commands = Console.ReadLine().Split();

            var data = commands[0];
            var rootSearch = commands[2];


            var IsFound = false;

            if (inputData.ContainsKey(rootSearch))
            {
                fileData = inputData[rootSearch]
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var file in fileData)
                {
                    var fileSplit = file.Key.Split('.');

                    if (fileSplit[fileSplit.Length - 1].Equals(data))
                    {
                        IsFound = true;
                        Console.WriteLine($"{file.Key} - {file.Value} KB");
                        
                    }
                }
            }
            if (!IsFound)
            {
                Console.WriteLine("No");
            }
        }

    }

}

