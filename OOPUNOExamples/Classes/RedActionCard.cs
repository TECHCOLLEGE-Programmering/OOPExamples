using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    internal class RedActionCard : RedCard, IActionable
    {
        internal RedActionCard() : base(0)
        {
        }
        int IActionable.Penalty()
        {
            //TODO: draw cards or skip turn.
            throw new NotImplementedException();
        }
        int IActionable.GetNumber()
        {
            throw new NotImplementedException();
        }
    }
}