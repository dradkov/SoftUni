namespace CharityMarathon
{
    using System;

    class CharityMarathon
    {
        static void Main(string[] args)
        {

            var days = int.Parse(Console.ReadLine());
            var numRunners = long.Parse(Console.ReadLine());
            var laps = int.Parse(Console.ReadLine());
            var trackLength = int.Parse(Console.ReadLine());
            var capacity = long.Parse(Console.ReadLine());
            var moneyDonate = decimal.Parse(Console.ReadLine());


            var numParticipants = capacity * days;

            if (numParticipants > numRunners)
            {
                numParticipants = numRunners;
            }

            var totalMeters = numParticipants * laps * trackLength;
            var totalKilometers = totalMeters / 1000;
            var moneyRaisedByKilometer = moneyDonate;
            var MoneyRaised = totalKilometers * moneyRaisedByKilometer;

            Console.WriteLine($"Money raised: {MoneyRaised:f2}");

        }
    }
}
