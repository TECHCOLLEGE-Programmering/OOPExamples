using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.UI
{
    internal delegate void OptionMethod();
    internal class MenuOption
    {
        protected MenuOption(string name)
        {
            this.optionName = name;
        }
        internal MenuOption(string name, OptionMethod optionMethod)
        {
            this.optionMethod = optionMethod;
            this.optionName = name;
        }
        protected readonly string optionName;
        internal readonly OptionMethod optionMethod;
        internal new string ToString()
        {
            return optionName;
        }
    }
}