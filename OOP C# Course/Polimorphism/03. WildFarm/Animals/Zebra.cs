using System;

    public class Zebra : Mammal
    {
        public Zebra(string name, string type, double weight, string livigRegion)
            : base(name, type, weight, livigRegion)
        {
        }

        public override string MakeSound()
        {
            return "Zs";
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
            }
            base.Eat(food);
        }
    }
