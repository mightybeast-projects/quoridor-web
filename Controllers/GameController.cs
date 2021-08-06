using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quoridor.Core.GameLogic;
using QuoridorWeb.WebApp;

namespace QuoridorWeb.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private Game _game;
        private WebDrawer _webDrawer;
        private string _errorMessage;
        
        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        public IActionResult Start()
        {
            _errorMessage = "";

            _game = new Game();
            _game.AddNewPlayerPair();
            _game.AddNewPlayerPair();
            _game.Start();
            _webDrawer = new WebDrawer(_game);
            return View(GetModel());
        }

        public IActionResult Move(int id)
        {
            _errorMessage = "";

            Console.WriteLine("Movement : " + id);
            try { _game.MakeCurrentPlayerMove((PlayerMove) id); }
            catch (Exception e) { _errorMessage = e.Message; }
            
            Console.WriteLine("Current player : " + _game.currentPlayerIndex);
            return View("Start", GetModel());
        }

        private GameViewModel GetModel()
        {
            return new GameViewModel()
            {
                game = _game, 
                errorMessage = _errorMessage,
                table = _webDrawer.GetBoard()
            };
        }
    }

    public class GameViewModel
    {
        public Game game {get; set; }
        public string errorMessage {get; set; }
        public string table {get; set; }
    }
}