using Microsoft.VisualBasic;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public class BlueActionCard : BlueCard, IActionable<ColoredActionCardType>
    {

        public BlueActionCard(ColoredActionCardType cardType) : base(10)
        {
            this.CardType = cardType;
        }
        public ColoredActionCardType CardType { get; set; }

        public int Penalty(Player player)
        {
            switch (CardType)
            {
                case ColoredActionCardType.SwitchDirection:
                    //TODO reposability to game controller
                    throw new NotImplementedException();
                    break;
                case ColoredActionCardType.SkipTurn:
                    //TODO reposability to game controller
                    throw new NotImplementedException();
                    break;
                case ColoredActionCardType.DrawTwo:
                    player.DrawCards(2);
                    break;
            }
            return 1; //TODO maybe void or bool
        }
        public uint GetNumber()
        {
            return this.number;
        }
        public override bool ToCompare(Card otherCard) {
            bool isCardSamecolor = IsCardSameColor(otherCard);
            bool isCardSameType = false;
            IActionable<ColoredActionCardType> otherICard = otherCard as IActionable<ColoredActionCardType>;
            if (number == 0)
            {
                isCardSameType = this.CardType.Equals(otherICard.CardType);
            }
            return isCardSamecolor || isCardSameType;
        }
    }
}