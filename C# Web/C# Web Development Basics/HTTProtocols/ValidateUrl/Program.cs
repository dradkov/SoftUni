namespace ValidateUrl
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

   public class Program
    {
       public static void Main(string[] args)
        {
            string url = Console.ReadLine();

            string decode = WebUtility.UrlDecode(url);

            Regex rgx = new
                Regex(@"(https|http):\/{2}([a-zA-Z0-9\.-]+)(\:\d+)?([\/][\w\W]+)");

            Match match = rgx.Match(decode);

            if (!match.Success)
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            Uri parsedUrl = new Uri(decode);


            if (string.IsNullOrEmpty(parsedUrl.Scheme) || string.IsNullOrEmpty(parsedUrl.Host))
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            else if (string.IsNullOrEmpty(parsedUrl.Query))
            {
                Console.WriteLine($"Protocol:{parsedUrl.Scheme}");
                Console.WriteLine($"Host:{parsedUrl.Host}");
                Console.WriteLine($"Port:{parsedUrl.Port}");
                Console.WriteLine($"Path:{parsedUrl.AbsolutePath}");
                return;
            }

            else if (string.IsNullOrEmpty(parsedUrl.Fragment))
            {
                Console.WriteLine($"Protocol:{parsedUrl.Scheme}");
                Console.WriteLine($"Host:{parsedUrl.Host}");
                Console.WriteLine($"Port:{parsedUrl.Port}");
                Console.WriteLine($"Path:{parsedUrl.AbsolutePath}");
                Console.WriteLine($"Query:{parsedUrl.Query}");
                return;
            }

            Console.WriteLine($"Protocol:{parsedUrl.Scheme}");
            Console.WriteLine($"Host:{parsedUrl.Host}");
            Console.WriteLine($"Port:{parsedUrl.Port}");
            Console.WriteLine($"Path:{parsedUrl.AbsolutePath}");
            Console.WriteLine($"Query:{parsedUrl.Query}");
            Console.WriteLine($"Fragment:{parsedUrl.Fragment}");

        }
    }
}
