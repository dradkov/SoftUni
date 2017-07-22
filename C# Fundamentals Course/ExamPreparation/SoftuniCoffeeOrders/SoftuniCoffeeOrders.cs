namespace SoftuniCoffeeOrders
{
    using System;
    using System.Globalization;

    class SoftuniCoffeeOrders
    {
        static void Main()
        {
            var orders = int.Parse(Console.ReadLine());


            decimal sum = 0;

            for (int i = 0; i < orders; i++)
            {
                var priceCaps = decimal.Parse(Console.ReadLine());
                var date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InstalledUICulture);
                var capsulsCount = long.Parse(Console.ReadLine());


                var totalDays = DateTime.DaysInMonth(date.Year, date.Month);

                var result = totalDays * capsulsCount * priceCaps;

                Console.WriteLine($"The price for the coffee is: ${result:f2}");

                sum += result;

            }

            Console.WriteLine($"Total: ${sum:f2}");
        }
    }
}
