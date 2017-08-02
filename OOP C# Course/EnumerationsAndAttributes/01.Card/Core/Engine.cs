namespace _01.Card.Core
{
    using System;
    using System.Collections.Generic;
    using _01.Card.Models;
    using _01.Card.Enums;
    using System.Linq;

    public class Engine
    {

        private readonly IList<Player> players;
        private readonly IList<Card> allCards;
        private readonly IList<Card> tempList;

        public Engine()
        {
            this.players = new List<Player>();
            this.allCards = new List<Card>();
            this.tempList = new List<Card>();
        }

        public void Run()
        {
            var cardRank = Enum.GetValues(typeof(CardRanks));
            var cardSuit = Enum.GetValues(typeof(CardSuits));

            foreach (var suit in cardSuit)
            {
                foreach (var rank in cardRank)
                {
                    allCards.Add(new Card(rank.ToString(), suit.ToString()));
                }
            }

            var firstPlayer = Console.ReadLine();
            var secondPlayer = Console.ReadLine();

            players.Add(new Player(firstPlayer));

            var player = players.First(p => p.Name == firstPlayer);

            while (tempList.Count != 5)
            {
                var cardInfo = Console.ReadLine()
                    .Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);


                try
                {
                    var card = new Card(cardInfo[0], cardInfo[2]);


                    if (allCards.Any(c => c.Rank.ToString() == cardInfo[0] && c.Suit.ToString() == cardInfo[2]))
                    {
                        tempList.Add(card);
                        var specialcard =
                            allCards.First(c => c.Rank.ToString() == cardInfo[0] && c.Suit.ToString() == cardInfo[2]);
                        allCards.Remove(specialcard);
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No such card exists.");

                }
            }
            var temp = tempList.OrderByDescending(x => x.CardPower).ToList();


            foreach (var card in temp)
            {
                player.AddCard(card);
            }

            players.Add(new Player(secondPlayer));

            player = players.First(p => p.Name == secondPlayer);

            tempList.Clear();

            while (tempList.Count != 5)
            {
                var cardInfo = Console.ReadLine()
                    .Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    var card = new Card(cardInfo[0], cardInfo[2]);


                    if (allCards.Any(c => c.Rank.ToString() == cardInfo[0] && c.Suit.ToString() == cardInfo[2]))
                    {
                        tempList.Add(card);
                        var specialcard =
                            allCards.First(c => c.Rank.ToString() == cardInfo[0] && c.Suit.ToString() == cardInfo[2]);
                        allCards.Remove(specialcard);
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No such card exists.");

                }
            }

            temp = tempList.OrderByDescending(c => c.CardPower).ToList();

            foreach (var card in temp)
            {
                player.AddCard(card);
            }

            var playerOne = players.First(p => p.Name == firstPlayer).Cards.Max(c => c.CardPower);
            var playerTwo = players.First(p => p.Name == secondPlayer).Cards.Max(c => c.CardPower);

            var max = Math.Max(playerTwo, playerOne);
         

            foreach (var play in players)
            {
                if (play.Cards.Max(c => c.CardPower) == max)
                {
                    Console.WriteLine(play);
                    return;
                    
                }

            }

        }

    }
}

