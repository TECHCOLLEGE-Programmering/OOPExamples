using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    internal abstract class Card
    {
        internal Card(uint number)
        {
            this.number = number;
        }
        internal uint number;
        internal virtual bool ToCompare(Card otherCard)
        {
            bool isCardSamecolor = otherCard.GetType() == this.GetType();
            bool isCardSameNumber = this.number == otherCard.number;
            bool isWildCard = otherCard.GetType() == typeof(WildCard);
            return isCardSamecolor || isCardSameNumber || isWildCard;
        }
        public new virtual string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType());
            sb.Append(' ');
            sb.Append(number);
            return sb.ToString();
        }
    }
}