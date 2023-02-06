using Microsoft.VisualBasic;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public class BlueActionCard : BlueCard, IActionable
    {

        public BlueActionCard(ActionCardType cardType) : base(0)
        {
            this.CardType = cardType;
        }
        public ActionCardType CardType { get; set; }

        int IActionable.Penalty()
        {
            //TODO: draw cards
            throw new NotImplementedException();
        }
        int IActionable.GetNumber()
        {
            throw new NotImplementedException();
        }
        public override bool ToCompare(Card otherCard) {
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