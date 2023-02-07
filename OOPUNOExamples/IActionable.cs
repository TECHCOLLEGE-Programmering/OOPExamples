using OOPUNOExamples.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples
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
    public interface IActionable<T>
    {
        public uint GetNumber(); //TODO is this needed?
        public int Penalty(Player player);
        public T CardType { get; set; }
    }
}