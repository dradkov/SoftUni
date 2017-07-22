namespace GenericList
{
    using System;

    public class Engine
    {
        public void Run()
        {
            var custamList = new CustamCommand<string>();

            string inputInfo;

            while ((inputInfo = Console.ReadLine()) != "END")
            {
                var command = inputInfo.Split();

                var token = command[0];

                switch (token)
                {
                    case "Add":
                        custamList.Add(command[1]);
                        break;
                    case "Remove":
                        custamList.Remove(int.Parse(command[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(custamList.Contains(command[1]));
                        break;
                    case "Swap":
                        custamList.Swap(int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(custamList.CountGreaterThan(command[1]));
                        break;
                    case "Max":
                        Console.WriteLine(custamList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(custamList.Min());
                        break;
                    case "Print":
                        foreach (var item in custamList.StoreData)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "Sort":
                        custamList.Sort();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

