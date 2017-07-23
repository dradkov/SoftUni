using System;

public class Circle : IDrawable
{ 


    public Circle(int radius)
    {
        this.Radius = radius;
    }

    public int Radius { get; private set; }

    public void Draw()
    {

        double r_In = this.Radius - 0.4;
        double r_Out = this.Radius + 0.4;


        for (double y = this.Radius; y >= -this.Radius; --y)
        {
            for (double x = -this.Radius; x < r_Out; x += 0.5)
            {
                double value = x * x + y * y;
                if (value>=r_In*r_In && value<=r_Out*r_Out)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }

    }
}

