using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    //TODO: Card should have number and color, but not if wild card.
    public enum CardEnum
    {
        Number,
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
        internal Card(CardEnum card)
        {
            CardType = card;
            if (CardType == CardEnum.Number)
            {
                number = 1;
            }
        }
        UInt16 number;
        internal CardEnum CardType { get; set; }
    }
}