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
        static private int IDCounter = 0;
        internal int ID { get; private set; }
        internal string Name
        {
            get => default;
            set
            {
            }
        }
        private List<Card> CardsInHand = new List<Card>();
        internal int GetHandSize()
        {
            return CardsInHand.Count;
        }
        internal static Deck Deck = new Deck(30, Deck.DeckTypeEnum.normal);
        internal bool Uno
        {
            get => default;
            set
            {
            }
        }
        internal Card PlayCard()
        {
            Array values = Enum.GetValues(typeof(CardEnum));
            foreach (CardEnum v in values)
            {

            }
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