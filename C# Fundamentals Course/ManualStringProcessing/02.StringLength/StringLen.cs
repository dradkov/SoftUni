namespace StringLength
{
    using System;

    public class StringLen
    {
        static void Main()
        {
            var text = Console.ReadLine();


            if (text.Length<= 20)
            {
                text = text.PadRight(20, '*');

            }

            Console.WriteLine(text);
        }
    }
}
