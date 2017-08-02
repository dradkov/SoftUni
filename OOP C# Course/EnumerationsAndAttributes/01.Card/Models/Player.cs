namespace _01.Card.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Player : IComparable<Player>
    {
        public Player(string name)
        {
            this.Name = name;
            this.Cards = new List<Card>();

        }


        public string Name { get; private set; }

        public IList<Card> Cards { get; private set; }


        public void AddCard(Card card)
        {
            this.Cards.Add(card);
        }


        public int CompareTo(Player other)
        {
            return 1;

        }

        public override string ToString()
        {

            return $"{this.Name} wins with {this.Cards.First().Rank} of {this.Cards.First().Suit}.";
        }
    }
}
