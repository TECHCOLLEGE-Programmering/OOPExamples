using OOPUNOExamples;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    internal class Deck : CardCollection
    {
        internal DiscardPile DiscardPile = new DiscardPile();
        internal Card DealCard()
        {
            Card topCard;
            try
            {
                topCard = Cards.Last();

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Shuffling dicard pile, except for top card...");
                Shuffle();
            }
            finally
            {
                topCard = Cards.Last();
                Cards.Remove(topCard);
            }
            return topCard;
        }
        /// <summary>
        /// Adds cards from discard pile and shuffels deck.
        /// </summary>
        private void Shuffle()
        {
            Card TopCard = DiscardPile.GetTopCard();
            DiscardPile.Cards.Remove(TopCard);
            Cards.AddRange(DiscardPile.Cards);
            var rnd = new Random();
            Cards.OrderBy(item => rnd.Next());
            DiscardPile = new DiscardPile();
        }
    }
}