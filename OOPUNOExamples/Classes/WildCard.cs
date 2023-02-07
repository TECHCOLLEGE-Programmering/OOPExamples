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

        public int Penalty(Player player)
        {
            if (CardType.Equals(WildActionCardType.DrawFour))
                player.DrawCards(4);
            //TODO change color
            throw new NotImplementedException();
        }
        public uint GetNumber()
        {
            return this.number;
        }
        public override bool ToCompare(Card otherCard)
        {
            return true;
        }
    }
}