using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AnimalFactory
{
    public static Animal GetAnimal(string[] tokens)
    {
        var animalType = tokens[0];
        var animalName = tokens[1];
        var animalWeight = double.Parse(tokens[2]);
        var animalLivingRegion = tokens[3];

        switch (animalType)
        {
            case "Mouse":
                return new Mouse(animalName, animalType, animalWeight, animalLivingRegion);

            case "Cat":
                return new Cat(animalName, animalType, animalWeight, animalLivingRegion, tokens[4]);

            case "Tiger":
                return new Tiger(animalName, animalType, animalWeight, animalLivingRegion);

            case "Zebra":
                return new Zebra(animalName, animalType, animalWeight, animalLivingRegion);
            default:
                return null;
        }
    }
}
