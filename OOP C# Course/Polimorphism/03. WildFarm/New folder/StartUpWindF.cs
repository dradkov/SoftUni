using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main()
    {
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            var animalsTokens = inputLine.Split(new[] { '\t', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var foodTokens = Console.ReadLine().Split(new[] { '\t', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Animal animal = AnimalFactory.GetAnimal(animalsTokens);
            Food food = FoodFactory.GetFood(foodTokens);

            Console.WriteLine(animal.MakeSound());
            try
            {
                animal.Eat(food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(animal);
        }
    }
}