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
            return otherCard.GetType() == this.GetType() || 
                otherCard.GetType().IsSubclassOf(this.GetType()) || 
                this.GetType().IsSubclassOf(otherCard.GetType());
        }
        public virtual bool ToCompare(Card otherCard)
        {
            bool isCardSameColor = IsCardSameColor(otherCard);
            bool isCardSameNumber = otherCard.number == this.number;
            bool isWildCard = otherCard.GetType() == typeof(WildCard) || 
                otherCard.GetType().IsSubclassOf(typeof(WildCard)); //TODO: color change of wildcard
            return isCardSameColor || isCardSameNumber || isWildCard;
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