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
        private readonly string title;
        private readonly string body;
        internal virtual void Draw()
        {
            Console.Clear();
            Console.Title = title;
            Console.WriteLine("{0,"+ GetCenterPlacement(title).ToString() + "}\n", title);
            Console.WriteLine("{0," + GetCenterPlacement(body).ToString() + "}", body);
        }
        protected int GetCenterPlacement(string text)
        {
            int width = Console.WindowWidth;
            int textWidth = text.Length;
            int centerPlacement = width / 2 + textWidth / 2 + 1;
            return centerPlacement;
        }
        protected int EnterIntValue(string promt)
        {
            int number;
            string str = "";
            do
            {
                try
                {
                    Console.WriteLine(promt);
                    str = Console.ReadLine();
                } 
                catch (NullReferenceException)
                {
                    Console.WriteLine("Please enter a number");
                }
            } while (!(int.TryParse(str, out number) && str != ""));
            return number;
        }
    }
}