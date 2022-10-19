using OOPUNOExamples.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.UI
{
    internal delegate void CardOptionMethod(out Card ChosenCard, Card card);
    internal class CardMenuOption : MenuOption
    {
        internal CardMenuOption(string name, CardOptionMethod optionMethod) : base(name)
        {
            this.optionMethod = optionMethod;
        }
        internal readonly new CardOptionMethod optionMethod;
    }
}