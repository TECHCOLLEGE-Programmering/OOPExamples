using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal class Deck
    {
        internal List<Card> Cards = new List<Card>();
        public Card DealCard()
        {
            Card topCard;
            try
            {
                topCard = Cards.Last();
                
            } catch (NullReferenceException)
            {
                Console.WriteLine("Shuffling dicard pile, except for top card...");
                //TODO: Add discard pile into deck
                //Shuffle();
            }
            finally
            {
                topCard = Cards.Last();
                Cards.Remove(topCard);
            }
            return topCard;
        }
        private void Shuffle()
        {
            throw new NotImplementedException();
        }
    }
}