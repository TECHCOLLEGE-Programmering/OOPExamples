using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal class RedCard : Card
    {
        internal override bool ToCompare(Card otherCard)
        {
            bool isCardSamecolor = otherCard.GetType() == typeof(RedCard);
            bool isCardSameNumber = this.number == otherCard.number;
            bool isWildCard = otherCard.GetType() == typeof(WildCard);
            return isCardSamecolor || isCardSameNumber || isWildCard;
        }
    }
}