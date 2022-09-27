﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OOPAccessModifiers
{
    internal class DeckCreator
    {
        internal Deck FactoryMethodNormalDeck()
        {
            const ushort amountOfPenaltyCards = 4;
            uint[] numberRange = {1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Deck deck = new Deck();
            foreach (uint number in numberRange)
            {
                deck.DeckOfCards.Add(new RedCard(number));
            }
            foreach (uint number in numberRange)
            {
                deck.DeckOfCards.Add(new BlueCard(number));
            }
            foreach(Card card in FactoryMethodSpecialCard(amountOfPenaltyCards, 1))
            {
                deck.DeckOfCards.Add(card);
            }
            foreach (Card card in FactoryMethodSpecialCard(amountOfPenaltyCards, 2))
            {
                deck.DeckOfCards.Add(card);
            }
            var rnd = new Random();
            deck.DeckOfCards.OrderBy(item => rnd.Next());
            return deck;
        }
        internal Deck FactoryMethodAdvancedDeck()
        {
            Deck deck = new Deck();
            throw new System.NotImplementedException();
            var rnd = new Random();
            deck.DeckOfCards.OrderBy(item => rnd.Next());
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
        internal List<Card> FactoryMethodSpecialCard(ushort amount, short type) //TODO: Make more readable
        {
            List<Card> cards = new List<Card>();
            switch(type){
                case 1:
                    for (ushort i = 0; i <= amount; i++)
                    {
                        cards.Add(new RedActionCard());
                    }
                    break;
                case 2:
                    for (ushort i = 0; i <= amount; i++)
                    {
                        cards.Add(new BlueActionCard());
                    }
                    break;
                case 3:
                    for (ushort i = 0; i <= amount; i++)
                    {
                        cards.Add(new WildCard());
                    }
                    break;
            }
            return cards;
        }
    }
}