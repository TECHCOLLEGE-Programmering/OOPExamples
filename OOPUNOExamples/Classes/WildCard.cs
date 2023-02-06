using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public class WildCard : Card, IActionable
    {
        ActionCardType IActionable.CardType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public WildCard() : base(0)
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
        public override bool ToCompare(Card otherCard)
        {
            return true;
        }
    }
}