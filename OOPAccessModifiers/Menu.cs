using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAccessModifiers
{
    public class Menu : Screen
    {
        internal Menu(string title, string body, List<string> options) : base(title, body)
        {
            this.options = options ?? new List<string>();
            SelectedIndex = 0;
        }
        private int selectedIndex;
        private int SelectedIndex 
        {
            get { return this.selectedIndex; }
            set
            {
                try
                {
                    string s = options[value];
                    this.selectedIndex = value;
                } catch (ArgumentOutOfRangeException)
                {
                    this.selectedIndex = 0;
                }
            }
        }
        List<string> options;
        internal override void Draw()
        {
            base.Draw();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("\n");
            foreach (string option in options)
            {
                if (option == options[SelectedIndex])
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                Console.WriteLine("{0," + GetCenterPlacement(option).ToString() + "}\n", option);
                Console.ResetColor();
            }
        }
        internal void MenuControl()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.Escape)
            {
                Draw();
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                }else if (key.Key == ConsoleKey.Enter)
                {
                    int numberOfPlayers;
                    switch (SelectedIndex)
                    {
                        case 0:
                            numberOfPlayers = EnterIntValue(
                                "Enter the number of players that will be partisipating in the game");
                            GameController.SetupGame(numberOfPlayers);
                            GameController.GameLoop();
                            break;
                        case 1:
                            numberOfPlayers = EnterIntValue(
                                "Enter the number of players that will be partisipating in the game");
                            GameController.SetupGame(numberOfPlayers);
                            break;
                        case 2:
                            //Winers list.
                            throw new NotImplementedException();
                            break;
                    }
                }
            }
        }
    }
}