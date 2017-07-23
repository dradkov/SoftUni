namespace Phone
{
    using System;

    public class StartUpTeleohony
    {
        static void Main(string[] args)
        {
            var phoneNumber = Console.ReadLine().Split();
            var url = Console.ReadLine().Split();


            var smartFone = new Smartphone();
            smartFone.Calling(phoneNumber);
            smartFone.Browsing(url);
        }
    }
}

