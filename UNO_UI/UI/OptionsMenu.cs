using OOPUNOExamples.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples
{
    public class OptionsMenu : Menu
    {
        internal OptionsMenu(string title, string body, List<MenuOption> options) : base(title, body, new List<Object>(options))
        {
            this.options = options ?? new List<MenuOption>();
            if (this.title != "Main Menu" && !this.title.Contains("Choose"))
            {
                this.options.Add(new MenuOption("Back", () => Menu.menuLoopControl = false));
            }
            this.options.Add(new MenuOption("Exit Game", () => Environment.Exit(0)));
        }

        private new List<MenuOption> options;
        internal void MenuControl()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do {
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
                            options[SelectedIndex].optionMethod();
                        }
                        catch (NullReferenceException)
                        {
                            continue;
                        }
                        break;
                    default:
                        GameController.MenuController();
                        break;
                }
            } while (key.Key != ConsoleKey.Escape && menuLoopControl) ;
            Menu.menuLoopControl = true;
        }
    }
}