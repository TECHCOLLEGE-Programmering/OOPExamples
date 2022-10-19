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
        public int Penalty()
        {
            //TODO: draw cards
            throw new NotImplementedException();
        }
    }
}