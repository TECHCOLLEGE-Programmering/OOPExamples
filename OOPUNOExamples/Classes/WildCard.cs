﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal class WildCard : Card, IActionable
    {
        internal WildCard() : base(0)
        {

        }
        public int Penalty()
        {
            //TODO: draw cards if wildcard +4
            throw new NotImplementedException();
        }
        internal override bool ToCompare(Card otherCard)
        {
            return true;
        }
    }
}