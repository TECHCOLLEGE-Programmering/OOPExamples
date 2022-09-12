using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal class RedActionCard : RedCard, IActionable
    {
        public int Penalty()
        {
            //TODO: draw cards
            throw new NotImplementedException();
        }
    }
}