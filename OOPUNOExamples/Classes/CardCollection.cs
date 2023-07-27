using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.Classes
{
    public abstract class CardCollection // TODO Consider Implementiong ICollection<T>
    {
        internal List<Card> Cards = new List<Card>();

        public void Shuffle()
        {
            throw new NotImplementedException(); //TODO Shuffle on CardCollection
        }
    }
}