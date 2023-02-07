using OOPUNOExamples.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OOPUNOExamples
{
    public class DeckCreator
    {
        public Deck FactoryMethodNormalDeck()
        {
            const ushort amountOfPenaltyCards = 4;
            uint[] numberRange = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            Deck deck = new Deck();
            foreach (uint number in numberRange)
            {
                deck.Cards.Add(new RedCard(number));
            }
            foreach (uint number in numberRange)
            {
                deck.Cards.Add(new BlueCard(number));
            }
            foreach(Card card in FactoryMethodSpecialCard(amountOfPenaltyCards, 1))
            {
                deck.Cards.Add(card);
            }
            foreach (Card card in FactoryMethodSpecialCard(amountOfPenaltyCards, 2))
            {
                deck.Cards.Add(card);
            }
            foreach (Card card in FactoryMethodSpecialCard(amountOfPenaltyCards, 3))
            {
                deck.Cards.Add(card);
            }
            var rnd = new Random();
            deck.Cards.OrderBy(item => rnd.Next());

            foreach (Card card in deck.Cards)
            {
                IActionable<ColoredActionCardType> IaCard = card as IActionable<ColoredActionCardType>;
                if (IaCard == null)
                {
                    deck.DiscardPile.AddCard(card);
                    break;
                }
            }

            return deck;
        }
        public Deck FactoryMethodAdvancedDeck()
        {
            Deck deck = new Deck();
            throw new System.NotImplementedException();
            var rnd = new Random();
            deck.Cards.OrderBy(item => rnd.Next()); //TODO: is not random right now
            return deck;
        }
        /// <summary>
        /// Makes an amount of penalty card based on the type represented by a short int.
        /// This could be done with an enum for better readability.
        /// An atempt using the Type of the objects, and could not figure it out.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private List<Card> FactoryMethodSpecialCard(ushort amount, short type) //TODO: Make more readable
        {
            Random rnd = new Random();
            Array ColoredValues = Enum.GetValues(typeof(ColoredActionCardType));
            Array wildValues = Enum.GetValues(typeof(WildActionCardType));
            List<Card> cards = new List<Card>();
            for (ushort i = 1; i <= amount; i++)
            {
                switch (type)
                {
                    case 1:
                        cards.Add(new RedActionCard((ColoredActionCardType)ColoredValues.GetValue(rnd.Next(ColoredValues.Length))));

                        break;
                    case 2:
                        cards.Add(new BlueActionCard((ColoredActionCardType)ColoredValues.GetValue(rnd.Next(ColoredValues.Length))));
                        break;
                    case 3:
                        cards.Add(new WildCard((WildActionCardType)wildValues.GetValue(rnd.Next(wildValues.Length))));
                        break;
                }
            }
            return cards;
        }
    }
}