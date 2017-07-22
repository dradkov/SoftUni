namespace SweetDessert
{
    using System;

    class SweetDessert
    {
        static void Main(string[] args)
        {
            var cash = double.Parse(Console.ReadLine());
            var numGuests = double.Parse(Console.ReadLine());
            var priceBananaUnit = double.Parse(Console.ReadLine());
            var priceEggsUnit = double.Parse(Console.ReadLine());
            var priceBerriesPerKilo = double.Parse(Console.ReadLine());


            var numPortion = Math.Ceiling(numGuests / 6);

            var neededBanana = numPortion * (2 * priceBananaUnit);
            var neededEgs = numPortion * (4 * priceEggsUnit);
            var neededBerrie = numPortion * (0.2 * priceBerriesPerKilo);


            var result = neededBanana + neededEgs + neededBerrie;

            if (result <= cash)
            {

                Console.WriteLine($"Ivancho has enough money - it would cost {result:f2}lv.");
            }
            else
            {
                var diff = result - cash;

                Console.WriteLine($"Ivancho will have to withdraw money - he will need {diff:f2}lv more.");

            }

        }
    }
}
