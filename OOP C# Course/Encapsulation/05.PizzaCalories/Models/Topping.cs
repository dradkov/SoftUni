namespace PizzaCalories.Models
{
    using System;

public class Topping
{
    private string type;
    private double weight;
    private const int basePerGram = 2;


    public Topping(string type,double weught)
    {
        this.Type = type;
        this.Weight = weught;

    }

    public string Type
    {
        get { return this.type; }
        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && 
                value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException(string.Format($"Cannot place {value} on top of your pizza."));
                
            }
            this.type = value;
        }
    }

    public double Weight
    {
        get { return this.weight; }

        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException(string.Format($"{this.Type} weight should be in the range [1..50]."));
            }
            this.weight = value;
        }

    }

        public double CalculateCalories()
        {
            double modifaier = basePerGram;

            switch (this.Type.ToLower())
            {
                case "meat": modifaier *= 1.2; break;
                case "veggies": modifaier *= 0.8; break;
                case "cheese": modifaier *= 1.1; break;
                case "sauce": modifaier *= 0.9; break;
                default:
                    break;
            }
            return modifaier * this.Weight;
        }

    }
}

