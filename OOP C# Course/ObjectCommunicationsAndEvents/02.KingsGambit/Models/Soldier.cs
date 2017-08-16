namespace _02.KingsGambit.Models
{
    using System;
    using _02.KingsGambit.Interface;

    public abstract class Soldier : ISoldier
    {
        protected Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get; }


        public abstract void Attack(object sender,EventArgs args);

    }
}
