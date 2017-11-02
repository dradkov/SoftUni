
using System;
using System.Collections.Generic;

public class Engine
{
    private IList<Animal> animals;

    public Engine()
    {
        this.animals = new List<Animal>();
    }


    public void Run()
    {

        string kindOfAnimal;
        while ((kindOfAnimal = Console.ReadLine()) != "Beast!")
        {
            var animalTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                switch (kindOfAnimal.ToLower().Trim())
                {
                    case "cat":
                        Animal cat = new Cat(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                        animals.Add(cat);
                        break;
                    case "dog":
                        Animal dog = new Dog(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                        animals.Add(dog);
                        break;

                    case "frog":
                        Animal frog = new Frog(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                        animals.Add(frog);
                        break;

                    case "kitten":
                        Animal kitten = new Kitten(animalTokens[0], int.Parse(animalTokens[1]), "Female");
                        animals.Add(kitten);
                        break;

                    case "tomcat":
                        Animal tomcat = new Tomcat(animalTokens[0], int.Parse(animalTokens[1]), "Male");
                        animals.Add(tomcat);
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }

        foreach (var an in animals)
        {
            Console.WriteLine(an.IntroduceAnimal());
            Console.WriteLine(an.ProduceSound());
        }
    }
  
}

