namespace PizzaCalories.Models
{
    using System;

    public class ProgrPizzaStartUp
    {
        static void Main(string[] args)
        {


            var info = Console.ReadLine();


            while (info != "END")
            {
                var split = info.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);


                if (split[0].ToLower() == "dough")
                {
                    try
                    {
                        var type = split[1];
                        var bakingMethod = split[2];
                        var weigth = double.Parse(split[3]);

                        var dough = new Dough(type, bakingMethod, weigth);
                        Console.WriteLine($"{dough.CalculateCalories():f2}");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        return;
                    }

                }
                else if (split[0].ToLower() == "topping")
                {
                    try
                    {
                        var type = split[1].ToLower();
                        var weigth = double.Parse(split[2]);

                        var top = new Topping(type, weigth);
                        Console.WriteLine($"{top.CalculateCalories():f2}");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        return;
                    }

                }
                else if (split[0].ToLower() == "pizza")
                {
                    var pizzaName = split[1];
                    var numOfToppings = int.Parse(split[2]);
                    if (numOfToppings > 10)
                    {
                        Console.WriteLine("Number of toppings should be in range [0..10].");
                        return;
                    }


                    var doughInfo = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    Pizza pizza;

                    try
                    {
                        var dough = new Dough(doughInfo[1].ToLower(), doughInfo[2].ToLower(), double.Parse(doughInfo[3]));
                        pizza = new Pizza(pizzaName, dough);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        return;
                    }
                    for (int i = 0; i < numOfToppings; i++)
                    {
                        var topings = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                        try
                        {
                            var toping = new Topping(topings[1], double.Parse(topings[2]));
                            pizza.Toping.Add(toping);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                            return;
                        }

                    }
                    Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():F2} Calories.");
                    return;

                }


                info = Console.ReadLine();
            }
        }
    }

}


