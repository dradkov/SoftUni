namespace MordorPlan
{
    using System;

    public class MordorsCrueltyStartUp
    {
        static void Main(string[] args)
        {
            var food = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);


            var result = 0; ;

            for (int i = 0; i < food.Length; i++)
            {
                switch (food[i].ToLower())
                {
                    case "cram": result += 2; break;
                    case "lembas": result += 3; break;
                    case "apple": result += 1; break;
                    case "melon": result += 1; break;
                    case "honeycake": result += 5; break;
                    case "mushrooms": result -= 10; break;
                    default:
                        result -= 1;
                        break;

                }

            }
            if (result < -5)
            {
                Console.WriteLine(result);
                Console.WriteLine("Angry");
            }
            else if (result >= -5 && result < 1)
            {
                Console.WriteLine(result);
                Console.WriteLine("Sad");
            }
            else if (result > 0 && result <= 15)
            {
                Console.WriteLine(result);
                Console.WriteLine("Happy");
            }
            else if (result > 15)
            {
                Console.WriteLine(result);
                Console.WriteLine("JavaScript");
            }
        }
    }
}

