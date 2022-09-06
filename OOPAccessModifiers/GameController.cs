using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAccessModifiers
{
    internal static class GameController
    {
        private static List<Player> players = new List<Player>();
        private static bool GameDone = true;
        public static void GameLoop()
        {
            GameDone = false;
            while (!GameDone)
            {
                foreach (Player player in players)
                {
                    Card card = player.PlayCard();
                    if (player.GetHandSize() == 0)
                    {
                        Console.WriteLine("player {0} won the game.", player.Name); 
                        GameDone = false;
                        break;
                    }
                    if (card == null)
                    {
                        player.DrawCard();
                    }
                    if (player.Uno)
                    {
                        Console.WriteLine("{0}: Uno!", player.Name);
                    }
                }
                Console.WriteLine("Press enter for next round");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    GameDone = true;
                    break;
                }
            }
            MenuController();
        }
        public static void MenuController()
        {
            List<string> menuOptions = new List<string>
            { "Start Game", "Choose Players", "See Winers" };
            Menu menu = new Menu("Game Menu", "here you can choose game mode and player", menuOptions);
            menu.MenuControl();
        }

        public static void SetupGame(int amountOfPlayers)
        {
            for (int i = 0; i < amountOfPlayers; i++)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Enter the name of Player {0}", i + 1);
                        players.Add(new Player(Console.ReadLine()));
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Please Enter a name in the console before hitting enter.");
                    }
                } while (players.Last().Name != null);
            }
            GameLoop();
        }
        public static void excuteCard(Player player, Card playedCard)
        {
            throw new System.NotImplementedException();
        }        
    }
}
