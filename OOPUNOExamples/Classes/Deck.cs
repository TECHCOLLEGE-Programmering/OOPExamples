using OOPUNOExamples;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal class Deck
    {
        internal List<Card> DeckOfCards = new List<Card>();
        internal DiscardPile DiscardPile = new DiscardPile();
        internal Card DealCard()
        {
            Card topCard;
            try
            {
                topCard = DeckOfCards.Last();
                
            } catch (NullReferenceException)
            {
                Console.WriteLine("Shuffling dicard pile, except for top card...");
                Shuffle();
            }
            finally
            {
                topCard = DeckOfCards.Last();
                DeckOfCards.Remove(topCard);
            }
            return topCard;
        }
        /// <summary>
        /// Adds cards from discard pile and shuffels deck.
        /// </summary>
        private void Shuffle()
        {
            Card TopCard = DiscardPile.GetTopCard();
            DiscardPile.DiscardCards.Remove(TopCard);
            DeckOfCards.AddRange(DiscardPile.DiscardCards);
            var rnd = new Random();
            DeckOfCards.OrderBy(item => rnd.Next());
            DiscardPile = new DiscardPile();
        }
    }
}