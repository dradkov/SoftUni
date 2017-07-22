namespace DistanceBetweenPoints
{
    using System;
    using System.Linq;

    class DistanceBetweenPoints
    {
        static void Main()
        {
            var firstLine = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var secondLine = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var firstPoint = new Points {X = firstLine[0],Y = firstLine[1] };
            var secondPoint = new Points {X= secondLine[0],Y=secondLine[1] };

            var result = CalculateTwoPoints(firstPoint, secondPoint);

            Console.WriteLine($"{result:F3}");
            

        }

        private static double CalculateTwoPoints(Points firstPoint, Points secondPoint)
        {
            var diffX = firstPoint.X - secondPoint.X;
            var diffY = firstPoint.Y - secondPoint.Y;

            var powX = Math.Pow(diffX, 2);
            var powY = Math.Pow(diffY, 2);

            var result = Math.Sqrt(powX + powY);

            return result;
        }
    }
}
