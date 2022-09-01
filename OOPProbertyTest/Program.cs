using System;

namespace OOPProbertyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c = new Class1("Jens","jens@gmail.com");
            Console.WriteLine(c.Name);
            c.Name = "Bob";
        }
    }
}
