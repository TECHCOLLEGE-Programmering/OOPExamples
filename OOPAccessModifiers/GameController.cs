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
            }
        }
        public static void StartGame()
        {
            throw new System.NotImplementedException();
        }

        public static void SetupGame(int amountOfPlayers)
        {
            for (int i = 0; i < amountOfPlayers; i++)
            {
                players.Add(new Player(Console.ReadLine()));
            }
            throw new System.NotImplementedException();
        }
        public static void excuteCard(Player player, Card playedCard)
        {
            throw new System.NotImplementedException();
        }        
    }
}
