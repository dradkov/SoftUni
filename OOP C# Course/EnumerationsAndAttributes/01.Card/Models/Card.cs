namespace _01.Card.Models
{
    using System;
    using _01.Card.Enums;


    public class Card : IComparable<Card>
    {


        public Card(string rank, string suit)
        {
            this.Rank = (CardRanks)Enum.Parse(typeof(CardRanks), rank);
            this.Suit = (CardSuits)Enum.Parse(typeof(CardSuits), suit);

        }

        public int CardPower
        {
            get
            {
                return (int)this.Rank + (int)this.Suit;
            }

        }


        public CardRanks Rank { get; private set; }
        public CardSuits Suit { get; private set; }


        public int CompareTo(Card other)
        {
            return (this.CardPower.CompareTo(other.CardPower));

        }

        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.CardPower}";
        }

        
    }
}
