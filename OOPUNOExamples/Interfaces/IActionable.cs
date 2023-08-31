using OOPUNOExamples.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Interfaces
{
    public enum ColoredActionCardType
    {
        SwitchDirection,
        SkipTurn,
        DrawTwo
    }
    public enum WildActionCardType
    {
        DrawFour,
        ChangeColor
    }
    public interface IActionable<T> // TODO why use generic?
    {
        public uint GetNumber(); //TODO is this needed?
        public void Penalty(Player nextPlayer);
        public T CardType { get; set; }
    }
}