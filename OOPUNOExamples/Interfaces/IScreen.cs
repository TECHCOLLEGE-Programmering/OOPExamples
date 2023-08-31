using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPUNOExamples.Interfaces
{
    internal interface IScreen
    {
        protected string title { get; set; }
        private string body { get; set; }
        public void Display();
        public string PromptUser(string promt);

    }
}
