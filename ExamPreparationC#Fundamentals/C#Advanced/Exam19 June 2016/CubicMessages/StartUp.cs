
namespace CubicMessages
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var pattern = @"^(\d+)([a-zA-Z]+)([^a-zA-Z]*)$";

            string inputMessage;

            while ((inputMessage = Console.ReadLine()) != "Over!")
            {
                var messageLenght = int.Parse(Console.ReadLine());

                Regex regex = new Regex(pattern);

                Match match = regex.Match(inputMessage);

                if (match.Success)
                {
                    string prefix = match.Groups[1].Value;
                    string message = match.Groups[2].Value;
                    string ending = String.Empty;

                    if (match.Groups[3].Value != "")
                    {
                        ending = match.Groups[3].Value;
                    }

                    if (message.Length != messageLenght)
                    {
                        continue;
                    }

                    string indexes = Regex.Replace(prefix+ending,@"\D*",string.Empty);

                    StringBuilder sb = new StringBuilder();

                    foreach (var index in indexes)
                    {
                        int ind = int.Parse(index.ToString());

                        if (ind >= 0 && ind < messageLenght)
                        {
                            sb.Append(message[ind]);
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }

                    Console.WriteLine($"{message} == {sb}");
                }
            }
        }
    }
}
