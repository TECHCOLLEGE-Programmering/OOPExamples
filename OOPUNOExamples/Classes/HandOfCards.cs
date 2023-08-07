using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPUNOExamples.Classes
{
    public class HandOfCards : CardCollection
    {
        public int GetHandSize()
        {
            return Cards.Count;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < Cards.Count; i++)
            {
                if (Cards[i] == Cards.Last())
                {
                    sb.AppendFormat("{0}: {1}", i, Cards[i].ToString());
                }
                else
                {
                    sb.AppendFormat("{0}: {1}\n", i, Cards[i].ToString());
                }
            }
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
