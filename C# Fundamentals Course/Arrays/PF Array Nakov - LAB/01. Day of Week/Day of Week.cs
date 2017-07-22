namespace DayOfWeek
{
    using System;

    class StartUp
    {
        static void Main()
        {
            int day = int.Parse(Console.ReadLine());

            string[] arr = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };


            if (day >= 1 && day <= 7)
            {
                Console.WriteLine(arr[(day - 1)]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}

