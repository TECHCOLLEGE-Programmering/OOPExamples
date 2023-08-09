using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public abstract class CardCollection // TODO Consider Implementiong ICollection<T>
    {
        internal List<Card> Cards = new List<Card>();

        public virtual void Shuffle()
        {
            Random rng = new();
            Cards = Cards.OrderBy(a => rng.Next()).ToList();
        }
    }
}