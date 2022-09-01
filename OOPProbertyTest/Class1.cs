using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProbertyTest
{
    class Class1
    {
        public Class1(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
        private string name;
        public string Name
        {
            get 
            {
                return name;
            }
            set 
            { 
                if(value.Length > 10)
                {
                    name = value;
                }
            }
        }
        public string Email
        {
            get; set;
        }
    }
}
