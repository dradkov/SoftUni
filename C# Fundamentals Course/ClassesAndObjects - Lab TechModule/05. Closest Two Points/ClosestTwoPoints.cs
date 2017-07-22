namespace ClosestTwoPoints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ClosestTwoPoints
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var listPoints = new List<PointsSecond>();

            for (int i = 0; i < n; i++)
            {
                var numsLine = Console.ReadLine().Split().Select(double.Parse).ToArray();

                listPoints.Add(new PointsSecond { X = numsLine[0], Y = numsLine[1] });

            }

            var minDistanceSoFar = double.MaxValue;
            PointsSecond firstPointMin = null;
            PointsSecond secondPointMin = null;

            for (int i = 0; i < listPoints.Count - 1; i++)
            {
                for (int k = i + 1; k < listPoints.Count; k++)
                {
                    var firstPoint = listPoints[i];
                    var secondPoint = listPoints[k];
                    var currentDistance = CalculateTwoPoints(firstPoint, secondPoint);

                    if (currentDistance < minDistanceSoFar)
                    {
                        minDistanceSoFar = currentDistance;
                        firstPointMin = firstPoint;
                        secondPointMin = secondPoint;
                    }

                }
            }

            Console.WriteLine($"{minDistanceSoFar:F3}");
            Console.WriteLine($"({firstPointMin.X}, {firstPointMin.Y})");
            Console.WriteLine($"({secondPointMin.X}, {secondPointMin.Y})");

        }
        private static double CalculateTwoPoints(PointsSecond firstPoint, PointsSecond secondPoint)
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
