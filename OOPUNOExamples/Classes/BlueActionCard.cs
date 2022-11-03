using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public class BlueActionCard : BlueCard, IActionable
    {
        public BlueActionCard() : base(0)
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