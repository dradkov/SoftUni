using System;
using _03.DependencyInversion.Models;

namespace _03.DependencyInversion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

            string inputInfo ;

            while ((inputInfo = Console.ReadLine())!="End")
            {
                string[] split = inputInfo.Split();

                if (split[0] == "mode")
                {      
                        calculator.ChangeStrategy(char.Parse(split[1]));                      
                }
                else
                {
                    int firstNumber = int.Parse(split[0]);
                    int secondNumber = int.Parse(split[1]);

                    Console.WriteLine(calculator.PerformCalculation(firstNumber,secondNumber));
                }
            }
        }
    }
}
