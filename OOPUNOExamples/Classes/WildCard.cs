using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    internal class WildCard : Card, IActionable
    {
        internal WildCard() : base(0)
        {

        }
        int IActionable.Penalty()
        {
            //TODO: draw cards if wildcard +4
            throw new NotImplementedException();
        }
        int IActionable.GetNumber()
        {
            throw new NotImplementedException();
        }
        internal override bool ToCompare(Card otherCard)
        {
            return true;
        }
    }
}