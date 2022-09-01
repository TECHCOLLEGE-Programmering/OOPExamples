using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    public class Menu : Screen
    {
        internal Menu(string title, string body) : base(title, body)
        {

        }
        List<string> options;
    }
}