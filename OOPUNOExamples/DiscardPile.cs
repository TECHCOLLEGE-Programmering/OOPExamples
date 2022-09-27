using OOPAccessModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples
{
    internal class DiscardPile
    {
        internal DiscardPile(Card topCard)
        {
            this.DiscardCards = new List<Card>();
            this.DiscardCards.Add(topCard);
        }
        internal DiscardPile()
        {
            this.DiscardCards = new List<Card>();
        }
        internal List<Card> DiscardCards;

        internal Card GetTopCard()
        {
            return DiscardCards.Last();
        }

        internal void AddCard(Card card)
        {
            DiscardCards.Add(card);
        }
    }
}