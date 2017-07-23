using System;
using System.Collections.Generic;

public class Engine
{
    public void Run()
    {
        string input;


        ICollection<Citizen> citizens = new List<Citizen>();

        while ((input= Console.ReadLine())!= "End")
        {
            var tokens = input.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            var name = tokens[0];
            var country = tokens[1];
            var age = int.Parse(tokens[2]);
            citizens.Add(new Citizen(name, country, age));


        }

        foreach (var man in citizens)
        {
            Console.WriteLine((man as IPerson).GetName());
            Console.WriteLine((man as IResident).GetName());
        }
    }
}
