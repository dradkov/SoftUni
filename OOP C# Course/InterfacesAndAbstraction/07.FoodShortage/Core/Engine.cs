
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {

            int numOfCommand = int.Parse(Console.ReadLine());

            ICollection<IPerson> buyers = new List<IPerson>();

            for (int i = 0; i < numOfCommand; i++)
            {
                var command = Console.ReadLine().Split();

                if (command.Length > 3)
                {
                    var name = command[0];
                    var age = int.Parse(command[1]);
                    var id = command[2];
                    var birthDay = command[3];

                    buyers.Add(new Citizen(name, age, id, birthDay));
                }
                else
                {
                    var name = command[0];
                    var age = int.Parse(command[1]);
                    var group = command[2];

                    buyers.Add(new Rebel(name, age, group));
                }
            }

            string inputInfo;

            while ((inputInfo = Console.ReadLine()) != "End")
            {

                if (buyers.Any(p => p.Name == inputInfo))
                {
                    var person = buyers.First(x => x.Name == inputInfo);
                    person.BuyFood();

                }

            }

            var totalFood = buyers.Sum(x => x.Food);

            Console.WriteLine(totalFood);

        }

    }


