using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public abstract class Card
    {
        public Card(uint number)
        {
            this.number = number;
        }
        internal uint number;
        protected bool IsCardSameColor(Card otherCard)
        {
            bool isWildCard = otherCard.GetType() == typeof(WildCard) ||
                otherCard.GetType().IsSubclassOf(typeof(WildCard));
            if (isWildCard) {
                WildCard c = otherCard as WildCard;
                if (c.Color == null)
                    return false;
                return c.Color.GetType() == this.GetType() ||
                c.Color.GetType().IsSubclassOf(this.GetType()) ||
                this.GetType().IsSubclassOf(c.Color.GetType());
            }
            else {
                return otherCard.GetType() == this.GetType() ||
                otherCard.GetType().IsSubclassOf(this.GetType()) ||
                this.GetType().IsSubclassOf(otherCard.GetType());
            }
        }
        public virtual bool ToCompare(Card otherCard)
        {
            bool isCardSameColor = IsCardSameColor(otherCard);
            bool isCardSameNumber = otherCard.number == this.number;
            return isCardSameColor || isCardSameNumber;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType());
            sb.Append(' ');
            sb.Append(number);
            return sb.ToString();
        }
    }
}