using System;
using System.Text;

public class Engine : IEngine
{
    public void Run()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        string input = reader.ReadLine();
        GameController gameController = new GameController();
        StringBuilder result = new StringBuilder();

        while (!input.Equals("Enough! Pull back!"))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException)
            {
            }

            input = reader.ReadLine();
        }

        result.AppendLine(gameController.RequestResult());
        writer.WriteLine(result.ToString().Trim());
    }
}