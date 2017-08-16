namespace _02.KingsGambit.Models
{
    using System;
    using _02.KingsGambit.Interface;


    public class King : ISoldier
    {
        public event EventHandler BeingAttacked;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; }


        public void TakeAttack()
        {
            this.StartAttack();
        }

        public virtual void StartAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");

            BeingAttacked?.Invoke(this,EventArgs.Empty);
        }
    }
}
