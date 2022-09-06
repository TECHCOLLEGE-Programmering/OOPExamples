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
            }
        }
    }
}