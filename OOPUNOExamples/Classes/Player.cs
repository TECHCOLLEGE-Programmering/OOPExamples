using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal class Player
    {
        internal Player(string name)
        {
            ID = IDCounter++;
            this.Name = name;
            CardsInHand = DrawCards(7);
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
            for (int i = 0; i < CardsInHand.Count; i++)
            {
                if (CardsInHand[i] == CardsInHand.Last())
                {
                    sb.AppendFormat("{0}: {1}.", i, CardsInHand[i].ToString());
                }
                else
                {
                    sb.AppendFormat("{0}: {1}, ", i, CardsInHand[i].ToString());
                }
            }
            Console.WriteLine(sb.ToString());
        }
        internal Card PlayCard()
        {
            PrintCardsInHand(); //TODO: maybe should be screen
            //get int index that is in list and pick card
            Card card = null;
            int cardIndex = -1;
            while (cardIndex >= 0 || card == null)
            {
                try
                {
                    cardIndex = int.Parse(Console.ReadLine());
                    card = CardsInHand[cardIndex];
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Please write a number from the list");
                    Console.WriteLine(ex);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Please write a number from the list");
                    Console.WriteLine(ex);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please write a number from the list");
                    Console.WriteLine(ex);
                }
            }
            //check if card fits
            bool LigalPlayAnd = card.ToCompare(Deck.DiscardPile.GetTopCard());
            bool IsInHand = CardsInHand.Remove(card);
            if (LigalPlayAnd && IsInHand)
            {
                Deck.DiscardPile.AddCard(card);
            }
            else
            {
                //TODO: what to do and better message.
                Console.WriteLine(LigalPlayAnd.ToString() + " " + LigalPlayAnd.ToString());
            }
            //else try again
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