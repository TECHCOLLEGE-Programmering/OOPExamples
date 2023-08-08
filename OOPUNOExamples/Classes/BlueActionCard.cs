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

        public void Penalty(Player nextPlayer)
        {
            if (this.CardType == ColoredActionCardType.SkipTurn)
            {
                nextPlayer.SkipTurn = true;
            }
            else if (this.CardType == ColoredActionCardType.SwitchDirection)
            {
                GameController.players.Reverse(); //TODO: test this with more than 2 players
                Console.WriteLine("Direction was reversed next player is {0}.", nextPlayer.Name);
                Console.ReadKey();
            }
            else if (this.CardType == ColoredActionCardType.DrawTwo)
            {
                nextPlayer.DrawCards(2);
                Console.WriteLine("{0} has to draw two cards!", nextPlayer.Name);
                Console.ReadKey();
            }
        }
        public uint GetNumber()
        {
            return this.number;
        }
        public override bool ToCompare(Card otherCard) {
            bool isCardSamecolor = IsCardSameColor(otherCard);
            bool isCardSameType = false;
            if (otherCard.GetType().GetInterfaces().Contains(typeof(IActionable<ColoredActionCardType>)))
            {
                IActionable<ColoredActionCardType> otherICard = otherCard as IActionable<ColoredActionCardType>;
                isCardSameType = this.CardType.Equals(otherICard.CardType);
            }
            return isCardSamecolor || isCardSameType;
        }
        public override string ToString()
        {
            return base.ToString() + " " + CardType.ToString();
        }
    }
}