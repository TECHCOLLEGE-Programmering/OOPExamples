using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    internal class BlueActionCard : BlueCard, IActionable
    {
        internal BlueActionCard() : base(0)
        {
        }
        int IActionable.Penalty()
        {
            //TODO: draw cards
            throw new NotImplementedException();
        }
        int IActionable.GetNumber()
        {
            throw new NotImplementedException();
        }
    }
}