using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public class RedActionCard : RedCard, IActionable
    {
        ActionCardType IActionable.CardType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public RedActionCard(ActionCardType cardType) : base(0)
        {
            this.CardType = cardType;
        }
        public ActionCardType CardType { get; set; }
        int IActionable.Penalty()
        {
            //TODO: draw cards or skip turn.
            throw new NotImplementedException();
        }
        int IActionable.GetNumber()
        {
            throw new NotImplementedException();
        }
        public override bool ToCompare(Card otherCard)
        {
            bool isCardSamecolor = IsCardSameColor(otherCard);
            bool isCardSameType = false;
            IActionable otherICard = otherCard as IActionable;
            if (number == 0)
            {
                isCardSameType = this.CardType.Equals(otherICard.CardType);
            }
            return isCardSamecolor || isCardSameType;
        }
    }
}