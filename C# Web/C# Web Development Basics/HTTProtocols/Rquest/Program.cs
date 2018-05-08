namespace Rquest
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> validUrls = new Dictionary<string, HashSet<string>>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {

                string[] tokens = input.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                string path = $"/{tokens[0]}";
                string method = tokens[1];

                if (!validUrls.ContainsKey(path))
                {
                    validUrls[path] = new HashSet<string>();
                }
                validUrls[path].Add(method);
            }

            string[] request = Console.ReadLine().Split(new[] { '/',' '},StringSplitOptions.RemoveEmptyEntries);

            string methodRequest = request[0].ToLower();
            string pathRequest = $"/{request[1]}";
            string protocol = $"{request[2]}/{request[3]}";

            int status = 200;
            string statusCode = "OK";

            int statusCodLen = statusCode.Length;

            if (validUrls.ContainsKey(pathRequest) && validUrls[pathRequest].Contains(methodRequest))
            {
                Console.WriteLine($"{protocol} {status} {statusCode}");
                Console.WriteLine($"Content-Length: {statusCodLen}");
                Console.WriteLine($"Content-Type: text/plain");
                Console.WriteLine();
                Console.WriteLine(statusCode);
                return;
            }

            status = 404;
            statusCode = "Not Found";
            statusCodLen = statusCode.Length;

            Console.WriteLine($"{protocol} {status} {statusCode}");
            Console.WriteLine($"Content-Length: {statusCodLen}");
            Console.WriteLine($"Content-Type: text/plain");
            Console.WriteLine();
            Console.WriteLine(statusCode);
 
        }
    }
}
