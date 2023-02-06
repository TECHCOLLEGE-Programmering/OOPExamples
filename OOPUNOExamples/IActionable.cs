using OOPUNOExamples.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples
{
    public enum ActionCardType
    {
        SwitchDirection,
        SkipTurn,
        ChangeColour,
    }
    public interface IActionable
    {
        internal int GetNumber();
        internal int Penalty();
        public ActionCardType CardType { get; set; }
    }
}