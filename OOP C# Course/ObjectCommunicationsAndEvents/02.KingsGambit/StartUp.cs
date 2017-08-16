namespace _02.KingsGambit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.KingsGambit.Models;

    public class StartUp
    {

        public static void Main(string[] args)
        {

            IList<Soldier> soldiers = new List<Soldier>();


            King king = new King(Console.ReadLine());

            var royalGuards = Console.ReadLine().Split();

            foreach (var royalGuard in royalGuards)
            {

                RoyalGuard guard = new RoyalGuard(royalGuard);

                soldiers.Add(guard);

                king.BeingAttacked += guard.Attack;

            }
            var footmans = Console.ReadLine().Split();

            foreach (var footman in footmans)
            {

                Footman guard = new Footman(footman);

                soldiers.Add(guard);

                king.BeingAttacked += guard.Attack;

            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var splitCommand = command.Split();

                switch (splitCommand[0])
                {
                    case "Attack":
                        king.TakeAttack();
                        break;

                    case "Kill":
                        Soldier soldier = soldiers.First(n => n.Name.Equals(splitCommand[1]));
                        king.BeingAttacked -= soldier.Attack;
                        soldiers.Remove(soldier);
                        break;
                }

            }
        }
    }
}
