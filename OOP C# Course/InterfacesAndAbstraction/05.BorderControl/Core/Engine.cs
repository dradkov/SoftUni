
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            string inputInfo;

            ICollection<IParticipant> listParticipants = new List<IParticipant>();

            while ((inputInfo = Console.ReadLine()) != "End")
            {
                var tokens = inputInfo.Split();

                if (tokens.Length > 2)
                {
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var id = tokens[2];

                    listParticipants.Add(new Citizen(name, age, id));
                }
                else
                {
                    var model = tokens[0];
                    var id = tokens[1];
                    listParticipants.Add(new Robot(model, id));

                }
            }
            var forbbitenNums = Console.ReadLine();

            var result = listParticipants.Where(p => p.Id.EndsWith(forbbitenNums));

            foreach (var denied in result)
            {
                Console.WriteLine(denied.Id);
            }
        }
    }


