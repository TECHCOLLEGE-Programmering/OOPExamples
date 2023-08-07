using OOPUNOExamples.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.UI
{
    internal class CardMenu : Menu
    {
        internal CardMenu(string title, string body, CardCollection options) : base(title, body, new List<Object>(options.Cards))
        {
            this.options = options.Cards ?? new List<Card>();
        }
        private new List<Card> options;
        /// <summary>
        /// Draw card options with dfferent colors if they are legal plays or not.
        /// </summary>
        internal override void Draw()
        {
            DrawTitle();
            foreach (Card cardOption in options)
            {
                if (cardOption == null)
                {
                    if (SelectedIndex == options.Count()-1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("{0," + GetCenterPlacement("Pass") + "}\n", "Pass");
                    }
                    else
                    {
                        Console.WriteLine("{0," + GetCenterPlacement("Pass") + "}\n", "Pass");
                    }
                } else
                {
                    if (cardOption == options[SelectedIndex])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    } else if (cardOption.ToCompare(Player.deck.DiscardPile.GetTopCard()))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    } else
                    {
                        Console.ResetColor();
                    }
                    Console.WriteLine("{0," + GetCenterPlacement(cardOption.ToString()) + "}\n", cardOption.ToString());
                }
                Console.ResetColor();
            }
        }
        internal Card MenuControl()
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
                        try
                        {
                            return options[SelectedIndex];
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            return null; //TODO game should end before
                        }
                        break;
                    case ConsoleKey.D0:
                        return null;
                        break;
                }
            } while (true);
        }
    }
}