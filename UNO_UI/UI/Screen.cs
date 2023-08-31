using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOPUNOExamples.Interfaces;

namespace OOPUNOExamples.UI
{
    public class Screen : IScreen
    {
        public Screen(string title, string body)
        {
            this.title = title;
            this.body = body;
            Console.ResetColor();
        }
        protected readonly string title;
        private readonly string body;
        internal void DrawTitle()
        {
            Console.Clear();
            Console.Title = title;
            Console.WriteLine("{0," + GetCenterPlacement(title) + "}\n", title);
            Console.WriteLine("{0," + GetCenterPlacement(body) + "}", body); //TODO: maybe spilt string per newline.
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("\n");
        }
        internal virtual void Draw()
        {
            DrawTitle();
        }
        protected string GetCenterPlacement(string text)
        {
            int width = Console.WindowWidth;
            int textWidth = text.Length;
            int centerPlacement = width / 2 + textWidth / 2 + 1;
            return centerPlacement.ToString();
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
        protected string EnterStringValue(string promt)
        {
            string value = null;
            do
            {
                try
                {
                    Console.WriteLine(promt);
                    value = Console.ReadLine();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Please enter something in the console before hitting enter.");
                }
            } while (value == null);
            return value;
        }
        public String PromtUser(string promt)
        {
            Console.Write("\n");
            return this.EnterStringValue(promt);
        }
    }
}