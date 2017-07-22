namespace ParseURLs
{
    using System;

    public class Url
    {
        static void Main()
        {

            var urlInput = Console.ReadLine().Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

            if (urlInput.Length != 2 || urlInput[1].IndexOf('/') == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            else
            {
                var protocol = urlInput[0];
                var server = urlInput[1].Substring(0, urlInput[1].IndexOf('/'));
                var resources = urlInput[1].Substring(urlInput[1].IndexOf('/') + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
        }
    }
}
