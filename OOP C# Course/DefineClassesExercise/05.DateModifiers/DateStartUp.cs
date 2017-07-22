namespace DateModifier
{
    using System;

    public class DateStartUp
    {
        static void Main()
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            DateModifier.FindDateDiffrences(firstDate, secondDate);
        }
    }
}

