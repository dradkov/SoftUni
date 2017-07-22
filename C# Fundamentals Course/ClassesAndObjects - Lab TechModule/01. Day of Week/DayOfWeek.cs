namespace DayOfWeek
{
    using System;    
    using System.Globalization;


    class DayOfWeek
    {
        

        static void Main()
        {
            var dateInput = Console.ReadLine();

            var date = DateTime.ParseExact(dateInput, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);

        }
    }
}
