using OOPUNOExamples.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public class WildCard : Card, IActionable<WildActionCardType>
    {
        public WildCard(WildActionCardType cardType) : base(11)
        {
            this.CardType = cardType;
        }
        public WildActionCardType CardType { get; set; }
        public Card Color { get; set; }
        public int Penalty(Player player)
        {
            if (CardType.Equals(WildActionCardType.DrawFour))
                player.DrawCards(4);
            //TODO change color
            throw new NotImplementedException();
        }
        public void ChooseColor()
        {
            CardCollection cardCollection = new HandOfCards();
            cardCollection.Cards.Add(new RedCard(0));
            cardCollection.Cards.Add(new BlueCard(0));
            CardMenu cardMenu = new CardMenu(
                "Choose a color", 
                "Here you can choose a color for your wild card.",
                cardCollection);
            cardMenu.Draw();
            Color = cardMenu.MenuControl();
        }
        public uint GetNumber()
        {
            return this.number;
        }
        public override bool ToCompare(Card otherCard)
        {
            return true;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(" - ");
            sb.Append(CardType.ToString());
            if (Color != null)
            {
                sb.Append(" - ");
                var s = Color.GetType().ToString().Split(".");
                sb.Append(s.Last());
            }
            return sb.ToString();
        }
    }
}