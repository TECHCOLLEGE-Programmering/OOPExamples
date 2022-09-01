using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    public enum CardEnum
    {
        Draw2,
        Reverse,
        Skip,
        Wild,
        WildDraw4,
        Trade,
        DiscardAllColor
    }
    internal class Card
    {
        internal CardEnum CardEnum { get; set; }
    }
}