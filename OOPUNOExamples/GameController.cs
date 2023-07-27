using OOPUNOExamples.Classes;
using OOPUNOExamples.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOPUNOExamples
{
    internal static class GameController //TODO: Make MVC
    {
        private static List<Player> players = new List<Player>();
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
            bool SkipTurn = false;
            while (!GameDone)
            {
                if (SkipTurn)
                {
                    SkipTurn = false;
                    continue;
                }
                for(int i = 0; i >= players.Count-1; i++) //TODO try with for loop
                {
                    Player player = players[i];
                    player.PlayCard();
                    if (player.GetHandSize() == 0)
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

                    //ActionCard Handling
                    //TODO: this should be in the ActionCard classes, to disribute responsibility.
                    Card topCard = Player.deck.DiscardPile.GetTopCard();

                    if (typeof(IActionable<ColoredActionCardType>).IsAssignableFrom(topCard.GetType())) 
                    {
                        //DEBUG: Console.WriteLine("Top card is a ColoredActionCardType");
                        IActionable<ColoredActionCardType> card = (IActionable<ColoredActionCardType>)topCard;
                        if (card.CardType == ColoredActionCardType.SkipTurn)
                        {
                            Console.WriteLine("{0} was skipped!", player.Name);
                            SkipTurn = true;
                        }
                        else if (card.CardType == ColoredActionCardType.SwitchDirection)
                        {
                            players.Reverse(); //TODO: test this with more than 2 players
                        }
                        else if (card.CardType == ColoredActionCardType.DrawTwo)
                        {
                            int nextPlayerIndex = i + 1;
                            players[nextPlayerIndex].DrawCards(2);
                            Console.WriteLine("{0} has to draw two cards!", players[nextPlayerIndex].Name);
                            SkipTurn = true;
                        }
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
