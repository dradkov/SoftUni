namespace MinerTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TaskMiner
    {
        static void Main()
        {
            var products = new Dictionary<string, int>();

            var resourses = Console.ReadLine();

            while(resourses!="stop")
            {
                var quontity = int.Parse(Console.ReadLine());

               

                if (!products.ContainsKey(resourses))
                {
                    products.Add(resourses, 0);
                }
                products[resourses] += quontity;


                resourses = Console.ReadLine();
            }

            if (products.Any())
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Key} -> {product.Value}");
                }
            }
           
        }
    }
}
