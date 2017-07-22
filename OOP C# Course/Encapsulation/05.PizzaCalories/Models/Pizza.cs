namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private List<Topping> toping;
        private Dough dough;


        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Toping = new List<Topping>();
            this.Dough = dough;

        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException(string.Format($"Pizza {value.ToUpper()} should be between 1 and 15 symbols."));
                }
                this.name = value;
            }
        }
        public List<Topping> Toping
        {
            get { return this.toping; }
            private set
            {
                this.toping = value;
            }
        }
        public Dough Dough
        {
            get { return this.dough; }
            set
            {
                this.dough = value;
            }
        }
        public int Topings(Topping toping)
        {

            return this.toping.Count();

        }
        public double TotalCalories()
        {

            double calories = 0;
            calories += this.dough.CalculateCalories();

            foreach (var top in this.toping)
            {
                calories += top.CalculateCalories();
            }

            return calories;
        }
    }
}

