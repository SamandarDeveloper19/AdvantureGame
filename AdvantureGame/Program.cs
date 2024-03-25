using AdvantureGame.Models;

namespace AdvantureGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameService gameService = new GameService();
            gameService.StartGame();
        }
    }
}