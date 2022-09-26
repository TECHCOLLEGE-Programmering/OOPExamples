using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    internal delegate void OptionMethod();
    internal class Menuoption
    {
        internal Menuoption(OptionMethod optionMethod, string name)
        {
            this.optionName = name;
            this.optionMethod = optionMethod;
        }
        private readonly string optionName;
        internal readonly OptionMethod optionMethod;
        internal new string ToString()
        {
            return optionName;
        }
    }
}