using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    public class Menu : Screen
    {
        internal Menu(string title, string body, List<Menuoption> options) : base(title, body)
        {
            this.options = options ?? new List<Menuoption>();
            if (this.title != "Main Menu" && !this.title.Contains("Choose"))
            {
                this.options.Add(new Menuoption(() => Menu.menuLoopControl = false, "Back"));
            }
            this.options.Add(new Menuoption(() => Environment.Exit(0), "Exit Game"));
            SelectedIndex = 0;
        }
        private List<Menuoption> options;
        private int selectedIndex;
        private int SelectedIndex 
        {
            get { return this.selectedIndex; }
            set
            {
                try
                {
                    string s = options[value].ToString();
                    this.selectedIndex = value;
                } catch (ArgumentOutOfRangeException)
                {
                    this.selectedIndex = 0;
                }
            }
        }
        internal static bool menuLoopControl = true;
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
                key = Console.ReadKey();
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
                        options[SelectedIndex].optionMethod();
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