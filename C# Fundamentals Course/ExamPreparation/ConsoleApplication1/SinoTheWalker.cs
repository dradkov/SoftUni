namespace SinoTheWalker
{
    using System;
    using System.Globalization;

    class SinoTheWalker
    {
        static void Main(string[] args)
        {
            var time = DateTime.ParseExact(Console.ReadLine()
                , "HH:mm:ss", CultureInfo.InvariantCulture);

            var numStep = long.Parse(Console.ReadLine());
            var timeStepInSeconds = long.Parse(Console.ReadLine());

            var sinoStep = numStep * timeStepInSeconds;

            var timeInSeconds = time.Hour * 60 * 60 + time.Minute * 60 + time.Second;

            var resultForCount = sinoStep + timeInSeconds;

            var second = resultForCount % 60;
            var timeInMinute = resultForCount / 60;
            var minute = timeInMinute % 60;
            var timeInHour = timeInMinute / 60;
            var hour = timeInHour % 24;

            Console.WriteLine($"Time Arrival: {hour:00}:{minute:00}:{second:00}");

        }
    }
}
