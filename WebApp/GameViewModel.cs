using Quoridor.Core.GameLogic;

namespace QuoridorWeb.WebApp
{
    public class GameViewModel
    {
        public string board {get; set; }
        public string errorMessage {get; set; }
        public int currentPlayerIndex {get; set;}
    }
}