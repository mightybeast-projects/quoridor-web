using Quoridor.Core.GameLogic;

namespace QuoridorWeb.WebApp
{
    public class GameViewModel
    {
        public Game game {get; set; }
        public string errorMessage {get; set; }
        public string table {get; set; }
    }
}