using OOPUNOExamples;
using OOPUNOExamples.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public class Player
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
            Hand = new HandOfCards();
            DrawCards(7);
        }
        private static int IDCounter = 0;
        internal int ID { get; private set; }
        internal string Name { get; private set; }
        public static Deck deck;
        public HandOfCards Hand { get; private set; }
        internal bool Uno
        {
            get => default;
            set
            {
            }
        }
        internal Card ChooseCard()
        {
            Card chosenCard = null;
            Card cardObj = null;

            string topCard = deck.DiscardPile.GetTopCard().ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("The top card {0}; ", topCard);
            sb.Append("If there are no card that you can or want to play press 0.");

            CardMenu menu = new CardMenu(Name, sb.ToString(), Hand);
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
                    IsInHand = Hand.Cards.Remove(card);
                }
                bool isWildCard = card.GetType() == typeof(WildCard);
                if (isWildCard)
                {
                    WildCard wildCard = card as WildCard;
                    wildCard.ChooseColor();
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
                        Hand.Cards.Add(card);
                    }
                    //DEBUG: Console.WriteLine(LegalPlay.ToString() + " " + LegalPlay.ToString());
                    Console.WriteLine("Card is not a legal play. Try again.");
                }
            }
            if (Hand.Cards.Count == 1)
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
            Hand.Cards.Add(topCard);
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