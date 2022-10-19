using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.UI
{
    public class Menu : Screen
    {
        internal Menu(string title, string body, List<MenuOption> options) : base(title, body)
        {
            this.options = options ?? new List<MenuOption>();
            if (this.title != "Main Menu" && !this.title.Contains("Choose"))
            {
                this.options.Add(new MenuOption("Back", () => Menu.menuLoopControl = false));
            }
            this.options.Add(new MenuOption("Exit Game", () => Environment.Exit(0)));
            SelectedIndex = 0;
        }
        private List<MenuOption> options;
        internal static bool menuLoopControl = true; //TODO: Maybe should be static
        private int selectedIndex;
        private int SelectedIndex 
        {
            get { return this.selectedIndex; }
            set
            {
                try
                {
                    options[value].ToString();
                    this.selectedIndex = value;
                } catch (ArgumentOutOfRangeException)
                {
                    this.selectedIndex = 0;
                }
            }
        }
        internal override void Draw()
        {
            base.Draw();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("\n");
            foreach (var option in options)
            {
                if (option == options[SelectedIndex])
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                Console.WriteLine("{0," + GetCenterPlacement(option.ToString()).ToString() + "}\n", option.ToString());
                Console.ResetColor();
            }
        }
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
                        options[SelectedIndex].optionMethod(); //TODO: What if it just returns the metod or object?
                        break;
                    default:
                        GameController.MenuController();
                        break;
                }
            } while ( key.Key != ConsoleKey.Escape && menuLoopControl );
            Menu.menuLoopControl = true;
        }
    }
}