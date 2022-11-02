using OOPUNOExamples;
using OOPUNOExamples.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace OOPUNOExamples.Classes
{
    internal class Player
    {
        internal Player(string name)
        {
            ID = IDCounter++;
            this.Name = name;
            DrawCards(7);
        }
        private static int IDCounter = 0;
        internal int ID { get; private set; }
        internal string Name { get; private set; }
        private List<Card> CardsInHand = new List<Card>();
        internal int GetHandSize()
        {
            return CardsInHand.Count;
        }
        internal static Deck Deck;
        internal bool Uno
        {
            get => default;
            set
            {
            }
        }
        private void PrintCardsInHand()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < CardsInHand.Count; i++)
            {
                if (CardsInHand[i] == CardsInHand.Last())
                {
                    sb.AppendFormat("{0}: {1}", i, CardsInHand[i].ToString());
                }
                else
                {
                    sb.AppendFormat("{0}: {1}\n", i, CardsInHand[i].ToString());
                }
            }
            Console.WriteLine(sb.ToString());
        }
        private Card ChooseCard()
        {
            Card chosenCard = null;
            Card cardObj = null;

            string topCard = Deck.DiscardPile.GetTopCard().ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("The top card {0}; ", topCard);
            sb.Append("If there are no card that you can or want to play press 0.");

            CardMenu menu = new CardMenu(Name, sb.ToString(), CardsInHand);
            chosenCard = menu.MenuControl();
            return chosenCard;
        }
        internal Card PlayCard()
        {
            Card card = null;
            bool success = false;
            card = ChooseCard();
            while (!success)
            {
                try
                {
                    bool LigalPlay = card.ToCompare(Deck.DiscardPile.GetTopCard());
                    bool IsInHand = CardsInHand.Remove(card);
                    if (LigalPlay && IsInHand)
                    {
                        Deck.DiscardPile.AddCard(card);
                        success = card != null;
                        //TODO execute Card penalties
                    }
                    else
                    {
                        //TODO: what to do and better message
                        CardsInHand.Add(card);
                        Console.WriteLine(LigalPlay.ToString() + " " + LigalPlay.ToString());
                        success = false;
                    }
                }
                catch (NullReferenceException)
                {
                    return card;
                }
            }
            return card;
        }
        internal Card DrawCard()
        {
            Card topCard = Deck.DealCard();
            this.CardsInHand.Add(topCard);
            return topCard;
        }
        internal List<Card> DrawCards(int Amount)
        {
            List<Card> topCards = new List<Card>();
            for (int i = 0; i < Amount; i++)
            {
                topCards.Add(DrawCard());
            }
            return topCards;
        }
    }
}