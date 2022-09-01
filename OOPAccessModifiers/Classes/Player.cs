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
            Name = name;
            CardsInHand = DrawCards(7);
        }
        static private int IDCounter;
        internal int ID { get; private set; }
        internal string Name
        {
            get => default;
            set
            {
            }
        }
        private List<Card> CardsInHand
        {
            get => default;
            set
            {
            }
        }
        internal int GetHandSize()
        {
            return CardsInHand.Count;
        }
        internal static Deck Deck
        {
            get => default;
            set
            {
            }
        }
        internal bool Uno
        {
            get => default;
            set
            {
            }
        }
        internal Card PlayCard()
        {
            throw new System.NotImplementedException();
        }
        internal Card DrawCard()
        {
            Card topCard = Deck.Cards.Last();
            Deck.Cards.Remove(topCard);
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