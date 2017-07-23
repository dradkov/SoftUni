namespace Shapes
{
    using System;

    public class StartUpShapes
    {
        static void Main()
        {
            Shape circle = new Circle(5);
            Shape rect = new Rectangle(2, 6);


            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(rect.CalculateArea());

        }
    }
}
