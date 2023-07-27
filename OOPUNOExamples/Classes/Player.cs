using OOPUNOExamples;
using OOPUNOExamples.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public class Player : CardCollection
    {
        public Player(string name)
        {
            ID = IDCounter++;
            this.Name = name;
            if (Player.deck == null)
            {
                DeckCreator deckCreator = new DeckCreator();
                Player.deck = deckCreator.FactoryMethodNormalDeck();
            }
            DrawCards(7);
        }
        private static int IDCounter = 0;
        internal int ID { get; private set; }
        internal string Name { get; private set; }
        public int GetHandSize()
        {
            return Cards.Count;
        }
        public static Deck deck;
        internal bool Uno
        {
            get => default;
            set
            {
            }
        }
        private void PrintCardsInHand()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < Cards.Count; i++)
            {
                if (Cards[i] == Cards.Last())
                {
                    sb.AppendFormat("{0}: {1}", i, Cards[i].ToString());
                }
                else
                {
                    sb.AppendFormat("{0}: {1}\n", i, Cards[i].ToString());
                }
            }
            Console.WriteLine(sb.ToString());
        }
        internal Card ChooseCard()
        {
            Card chosenCard = null;
            Card cardObj = null;

            string topCard = deck.DiscardPile.GetTopCard().ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("The top card {0}; ", topCard);
            sb.Append("If there are no card that you can or want to play press 0.");

            CardMenu menu = new CardMenu(Name, sb.ToString(), Cards);
            chosenCard = menu.MenuControl();
            return chosenCard;
        }
        internal Card PlayCard()
        {
            //TODO execute penalty if player can't put on next card.
            //TODO keep track of how many draw card has been chained.
            Card card = null;
            bool success = false;
            bool LegalPlay;
            bool IsInHand;
            while (!success)
            {
                card = ChooseCard(); //TODO if not legal draw card instead.
                if (card == null)
                {
                    DrawCard();
                    return deck.DiscardPile.GetTopCard();
                }
                else
                {
                    Card otherCard = deck.DiscardPile.GetTopCard();
                    LegalPlay = card.ToCompare(otherCard); //TODO: Null ref doesn't catch
                    IsInHand = Cards.Remove(card);
                }
                if (LegalPlay && IsInHand)
                {
                    deck.DiscardPile.AddCard(card);
                    success = card != null;
                    //TODO execute Card penalties
                }
                else
                {
                    if (card != null)
                    {
                        Cards.Add(card);
                    }
                    //DEBUG: Console.WriteLine(LegalPlay.ToString() + " " + LegalPlay.ToString());
                    Console.WriteLine("Card is not a legal play. Try again.");
                }
            }
            if (Cards.Count == 1)
            {
                Uno = true;
            }
            else
            { 
                Uno = false;
            }
            return card;
        }
        public Card DrawCard()
        {
            Card topCard = deck.DealCard();
            this.Cards.Add(topCard);
            return topCard;
        }
        public List<Card> DrawCards(int Amount)
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