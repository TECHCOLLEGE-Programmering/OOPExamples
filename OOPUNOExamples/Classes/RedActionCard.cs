using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public class RedActionCard : RedCard, IActionable
    {
        public RedActionCard() : base(0)
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