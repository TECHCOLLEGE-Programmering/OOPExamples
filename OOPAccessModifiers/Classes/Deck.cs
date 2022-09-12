using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal class Deck
    {
        public Deck(int deckSize, DeckTypeEnum deckType)
        {
            type = deckType;
            MakeDeck(deckSize);
        }
        internal enum DeckTypeEnum
        {
            advanced,
            normal
        }
        internal DeckTypeEnum type;
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
        private void MakeDeck(int deckSize)
        {
            if (type == DeckTypeEnum.advanced)
            {
                throw new NotImplementedException();
            }
            else if (type == DeckTypeEnum.normal)
            {
                Random random = new Random();
                Array values = Enum.GetValues(typeof(CardEnum));
                for (int i = 0; i < deckSize; i++)
                {
                    CardEnum randomCard = (CardEnum)values.GetValue(random.Next(values.Length));
                    Cards.Add(new Card(randomCard));
                }
                //TODO: Add nessesary card and then shuffle deck
                //Shuffle();
            }
        }
        private void Shuffle()
        {
            throw new NotImplementedException();
        }
    }
}