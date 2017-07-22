namespace ClassBox
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BoxStartUp
    {
        static void Main()
        {

            try
            {
                Type boxType = typeof(Box);
                FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                Console.WriteLine(fields.Count());


                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());


                var box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.GetSurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.GetVolume():f2}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}

