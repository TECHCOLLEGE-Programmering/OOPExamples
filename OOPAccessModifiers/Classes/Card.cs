using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal abstract class Card
    {
        internal Card(uint number)
        {
            this.number = number;
        }
        internal uint number;
        internal abstract bool ToCompare(Card otherCard);
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