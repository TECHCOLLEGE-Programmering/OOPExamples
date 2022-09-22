using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal class RedActionCard : RedCard, IActionable
    {
        internal RedActionCard() : base(0)
        {

        }
        public int Penalty()
        {
            //TODO: draw cards
            throw new NotImplementedException();
        }
    }
}