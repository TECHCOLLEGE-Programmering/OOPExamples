using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public class DiscardPile : CardCollection
    {
        public DiscardPile(Card topCard)
        {
            this.Cards = new List<Card>();
            this.Cards.Add(topCard);
        }
        internal Card GetTopCard()
        {
            return Cards.Last();
        }
        internal void AddCard(Card card)
        {
            Cards.Add(card);
        }
    }
}