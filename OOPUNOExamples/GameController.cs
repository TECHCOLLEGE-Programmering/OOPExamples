using OOPUNOExamples.Classes;
using OOPUNOExamples.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOPUNOExamples
{
    internal static class GameController //TODO: Make MVC
    {
        internal static List<Player> players = new List<Player>();
        private static bool GameDone = true;
        private static int numberOfPlayers = 2;
        public static void GameLoop()
        {
            if (players.Count < 2)
            {
                Console.WriteLine("You have to setup the game before you can start."); //TODO: could throw an exception here.
                return;
            }

            GameDone = false;
            while (!GameDone)
            {
                for(int i = 0; i <= players.Count-1; i++) //TODO try with for loop
                {
                    Player player = players[i];
                    if (player.SkipTurn)
                    {
                        Console.WriteLine("{0} was skipped!", player.Name);
                        player.SkipTurn = false;
                        Console.ReadKey();
                        continue;
                    }
                    Card playedCard = player.PlayCard();
                    //ActionCard Handling
                    bool IsColoredActionCard = playedCard.GetType().GetInterfaces().Contains(typeof(IActionable<ColoredActionCardType>));
                    bool IsWildCard = playedCard.GetType().GetInterfaces().Contains(typeof(IActionable<WildActionCardType>));
                    if (IsColoredActionCard || IsWildCard)
                    {
                        //DEBUG: Console.WriteLine("Top card is a ColoredActionCardType");
                        int nextPlayerIndex = (i + 1) % (players.Count);
                        if (IsWildCard)
                        {
                            IActionable<WildActionCardType> card = playedCard as IActionable<WildActionCardType>;
                            card.Penalty(players[nextPlayerIndex]);
                        }
                        else if (IsColoredActionCard)
                        {
                            IActionable<ColoredActionCardType> card = playedCard as IActionable<ColoredActionCardType>;
                            card.Penalty(players[nextPlayerIndex]);
                        }
                    }
                    if (player.Hand.GetHandSize() == 0)
                    {
                        Console.WriteLine("player {0} won the game!", player.Name); 
                        LogPlayerWin(player);
                        GameDone = false;
                        Console.Read();
                        break;
                    }
                    if (player.Uno)
                    {
                        Console.WriteLine("{0}: Uno!", player.Name);
                    }
                }
                Console.WriteLine("Press enter for next round or ESC to stop playing.");
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
            List<MenuOption> menuOptions = new List<MenuOption>
            {
                new MenuOption(nameof(DebugSetupGame), DebugSetupGame),
                new MenuOption(nameof(SetupGame), SetupGame),
                new MenuOption(nameof(GameLoop), GameLoop),
                new MenuOption(nameof(GetPlayerList), GetPlayerList)
            };
            OptionsMenu menu = new OptionsMenu(
                "Main Menu", 
                "here you can choose game mode and player", 
                menuOptions);

            menu.MenuControl();
        }
        public static void SetupGame() //TODO: this should be a screen
        {
            DeckCreator deckCreator = new DeckCreator();
            List<MenuOption> menuOptions = new List<MenuOption>
            {
                new MenuOption("Create A Normal Deck", delegate ()
                {
                    Player.deck = deckCreator.FactoryMethodNormalDeck();
                    OptionsMenu.menuLoopControl = false;
                }),
                new MenuOption("Create A Advanced Deck", delegate ()
                {
                    Player.deck = deckCreator.FactoryMethodAdvancedDeck();
                    OptionsMenu.menuLoopControl = false;
                })
            };
            OptionsMenu menu = new OptionsMenu("Choose Deck Type", "Here you can choose what kinda of deck the game should use. Press ECS to Exit.", menuOptions);
            menu.MenuControl();

            PromtScreen screen = new PromtScreen("Name Players", "Here you can give each player a name for the game. The game needs 2 - 4 players.");
            screen.Draw();
            string name;
            do
            {
                name = screen.PromtUser(String.Format("Enter the name of a player {0}.", players.Count + 1));
                players.Add(new Player(name));
                Console.WriteLine("Would you like to add another player. Press y/n.");
                if (Console.ReadKey(true).Key != ConsoleKey.Y)
                {
                    break;
                }
            } while (players.Count < 4);
        }
        public static void DebugSetupGame() //TODO: this should be a screen
        {

            DeckCreator deckCreator = new DeckCreator();
            Player.deck = deckCreator.FactoryMethodNormalDeck();

            players.Add(new Player("lkri"));
            players.Add(new Player("sinb"));
        }
        public static void GetPlayerList()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Player player in players)
            {
                if (player == players.Last())
                {
                    sb.Append(player.Name.ToString());
                }
                else
                {
                    sb.Append(player.Name.ToString() + ", ");
                }
            }
            Screen screen = new Screen("Player List", sb.ToString());
            screen.Draw();
            Console.ReadLine();
        }
        private static void LogPlayerWin(Player player)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(player.Name); //TODO: flesh out log describtion, number of rounds after win?
            File.AppendAllText("log.txt", sb.ToString());
            sb.Clear();
        }
    }
}
