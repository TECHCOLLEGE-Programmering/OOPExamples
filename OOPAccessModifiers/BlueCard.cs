using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal class BlueCard : Card
    {
        internal override bool ToCompare(Card otherCard)
        {
            bool isCardSamecolor = otherCard.GetType() == typeof(BlueCard);
            bool isCardSameNumber = this.number == otherCard.number;
            bool isWildCard = otherCard.GetType() == typeof(WildCard);
            return isCardSamecolor || isCardSameNumber || isWildCard;
        }
    }
}