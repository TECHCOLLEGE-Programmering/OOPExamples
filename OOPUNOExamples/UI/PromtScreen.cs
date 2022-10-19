using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.UI
{
    public class PromtScreen : Screen
    {
        public PromtScreen(string title, string body) : base(title, body)
        {
        }
        public String PromtUser(string promt)
        {
            Console.Write("\n");
            return this.EnterStringValue(promt);
        }
    }
}