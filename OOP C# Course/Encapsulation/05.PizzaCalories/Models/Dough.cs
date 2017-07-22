namespace PizzaCalories.Models
{
    using System;

    public class Dough
    {

        private string type;
        private string bakingMethod;
        private double weigth;

        private const int basePerGram = 2;

        public Dough(string type, string bakingMethod, double weigth)
        {
            this.Type = type;
            this.BakingMethod = bakingMethod;
            this.Weigth = weigth;

        }

        public string Type
        {
            get { return this.type; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");

                }

                this.type = value;

            }
        }
        public string BakingMethod
        {
            get { return this.bakingMethod; }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");

                }
                this.bakingMethod = value;
            }
        }
        public double Weigth
        {
            get { return this.weigth; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weigth = value;
            }
        }

        public double CalculateCalories()
        {
            double modifaier = basePerGram;



            switch (this.Type.ToLower())
            {
                case "white": modifaier *= 1.5; break;
                case "wholegrain": modifaier *= 1.0; break;
                default:
                    break;
            }
            switch (this.BakingMethod.ToLower())
            {
                case "crispy": modifaier *= 0.9; break;
                case "chewy": modifaier *= 1.1; break;
                case "homemade": modifaier *= 1.0; break;
                default:
                    break;
            }

            return modifaier * this.Weigth;
        }
    }
}

