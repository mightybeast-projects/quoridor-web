using System.Net;
using System;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quoridor.Core.GameLogic;
using QuoridorWeb.WebApp;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace QuoridorWeb.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private Game _game;
        private WebDrawer _webDrawer;
        private string _errorMessage;
        private Vector2 _wallStartPosition;
        private Vector2 _wallEndPosition;
        
        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        public IActionResult Start()
        {
            _errorMessage = "";

            _game = new Game();
            _game.AddNewPlayerPair();
            _game.Start();
            _webDrawer = new WebDrawer(_game);
            return View(GetModel());
        }

        public IActionResult Move(int moveId)
        {
            _errorMessage = "";

            try { _game.MakeCurrentPlayerMove((PlayerMove) moveId); }
            catch (Exception e) { _errorMessage = e.Message; }
            
            return View("Start", GetModel());
        }

        public IActionResult PlaceWall(string modelJson)
        {
            _errorMessage = "";

            DecerializeModelJson(modelJson);
            Console.WriteLine(_wallStartPosition + " " + _wallEndPosition);

            try { _game.MakeCurrentPlayerPlaceWall(_wallStartPosition, _wallEndPosition); }
            catch (Exception e) { _errorMessage = e.Message; }
            
            return View("Start", GetModel());
        }

        private void DecerializeModelJson(string modelJson)
        {
            var model = JsonConvert.DeserializeObject<WallModel>(modelJson);
            string[] wallStartPositionStr = model.wallStartPosition.Split(" ");
            string[] wallEndPositionStr = model.wallEndPosition.Split(" ");
            _wallStartPosition = new Vector2(Int32.Parse(wallStartPositionStr[0]), Int32.Parse(wallStartPositionStr[1]));
            _wallEndPosition = new Vector2(Int32.Parse(wallEndPositionStr[0]), Int32.Parse(wallEndPositionStr[1]));
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
}