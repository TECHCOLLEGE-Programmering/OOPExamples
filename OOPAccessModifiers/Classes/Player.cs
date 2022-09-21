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
        static private int IDCounter = 0;
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
        internal Card PlayCard()
        {
            throw new NotImplementedException();
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