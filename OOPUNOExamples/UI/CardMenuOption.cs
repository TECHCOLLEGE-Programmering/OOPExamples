using OOPUNOExamples.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.UI
{
    internal class CardMenu : Menu
    {
        internal CardMenu(string title, string body, List<Card> options) : base(title, body, new List<Object>(options))
        {
            this.options = options ?? new List<Card>();
        }
        private new List<Card> options;
        internal new Card MenuControl()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                Draw();
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        SelectedIndex--;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        SelectedIndex++;
                        break;
                    case ConsoleKey.Enter:
                        return options[SelectedIndex];
                        break;
                    case ConsoleKey.D0:
                        return null;
                        break;
                }
            } while (true);
        }
    }
}