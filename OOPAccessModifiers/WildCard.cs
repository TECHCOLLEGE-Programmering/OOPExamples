using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal class WildCard : Card, IActionable
    {
        public int Penalty()
        {
            //TODO: draw cards if wildcard +4
            throw new NotImplementedException();
        }
        internal override bool ToCompare(Card otherCard)
        {
            throw new NotImplementedException(); //TODO: implemen a way to check for chosen color.
        }
    }
}