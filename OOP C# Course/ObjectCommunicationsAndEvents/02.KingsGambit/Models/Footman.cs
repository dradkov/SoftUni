namespace _02.KingsGambit.Models
{
    using System;

    public class Footman : Soldier
    {
            public Footman(string name)
                : base(name)
            {
            }

            public override void Attack(object source, EventArgs args)
            {
                Console.WriteLine($"Footman {this.Name} is panicking!");
            }

    }
}
