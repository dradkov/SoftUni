namespace Monopoly
{
    using System;

    public class StartUp
    {

        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine().Split()[0]);

            int turns = 0;
            int money = 50;
            int numberOfHotels = 0;

           

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                string currentRow = Console.ReadLine();

                for (int coIndex = 0; coIndex < currentRow.Length; coIndex++)
                {
                    int index = rowIndex % 2 == 0 ? coIndex : currentRow.Length - coIndex - 1;

                    switch (currentRow[index])
                    {
                        case 'H':
                            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {++numberOfHotels}.");
                            money = 0;                           
                            break;
                        case 'J':
                            Console.WriteLine($"Gone to jail at turn {turns}.");
                            money += 2 * (numberOfHotels * 10);
                            turns += 2;
                            break;
                        case 'S':
                            int columnIndex = rowIndex % 2 == 0 ? coIndex : index;
                            int moneyToSpend = Math.Min((columnIndex + 1) * (rowIndex + 1), money);
                            money -= moneyToSpend;
                            Console.WriteLine($"Spent {moneyToSpend} money at the shop.");
                            break;
                    }

                    money += numberOfHotels * 10;
                    turns++;
                }
            }

            Console.WriteLine("Turns " + turns);
            Console.WriteLine("Money " + money);
        }
    }
}
