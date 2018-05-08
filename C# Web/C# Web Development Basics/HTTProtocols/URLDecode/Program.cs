namespace URLDecode
{
    using System;
    using System.Net;

    public class Program
    {
       
        private static void UrlDecode()
        {
            string url = Console.ReadLine();

            string decode = WebUtility.UrlDecode(url);

            Console.WriteLine(decode);
        }
    }
}
