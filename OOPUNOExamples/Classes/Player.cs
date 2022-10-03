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
            for (int i = 0; i < CardsInHand.Count; i++)
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
            string topCard = Deck.DiscardPile.GetTopCard().ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("The top card {0} \n", topCard);
            Console.WriteLine(sb.ToString());

            PrintCardsInHand(); //TODO: maybe should be screen
                                //get int index that is in list and pick card
            Console.WriteLine("If there are no card that you can or want to play press 0.");
            int cardIndex = -1;
            while(true)
            {
                try
                {
                    cardIndex = int.Parse(Console.ReadLine());
                    return CardsInHand[cardIndex];
                }
                catch (IndexOutOfRangeException ex)
                {
                    return null;
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
        }
        internal Card PlayCard()
        {
            Card card = null;
            bool success = false;
            card = ChooseCard();
            while (!success)
            {
                //check if card fits
                bool LigalPlayAnd = card.ToCompare(Deck.DiscardPile.GetTopCard());
                bool IsInHand = CardsInHand.Remove(card);
                if (LigalPlayAnd && IsInHand)
                {
                    Deck.DiscardPile.AddCard(card);
                    success = card != null;
                }
                else
                {
                    //TODO: what to do and better message.
                    Console.WriteLine(LigalPlayAnd.ToString() + " " + LigalPlayAnd.ToString());
                    success = false;
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