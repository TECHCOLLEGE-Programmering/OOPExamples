using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    public abstract class Screen
    {
        protected Screen(string title, string body)
        {
            this.title = title;
            this.body = body;
        }
        string title;
        string body;
        internal void Draw()
        {
            throw new NotImplementedException();
        }
    }
}