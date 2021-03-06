using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Quoridor.Core;
using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic;
using QuoridorWeb.WebApp.Drawable;

namespace QuoridorWeb.WebApp
{
    public class WebDrawer
    {
        private Board _board;
        private List<Player> _players;
        private Player _currentPlayer;
        private StringBuilder _table;
        private IDrawable _drawable;

        public WebDrawer(Game game)
        {
            _board = game.board;
            _players = game.players;
        }

        public string GetBoard()
        {
            _table = new StringBuilder();

            DrawTiles();

            return _table.ToString();
        }

        private void DrawTiles()
        {
            _table.Append("<table id='board'>");

            for (int i = _board.grid.GetLength(0) - 1; i >= 0; i--)
            {
                _table.Append("<tr>");

                for (int j = 0; j < _board.grid.GetLength(1); j++)
                    DrawBoardUnit(j, i);

                _table.Append("</tr>");
            }

            _table.Append("</table>");
        }

        private void DrawBoardUnit(int i, int j)
        {
            ChooseDrawable(i, j);

           _table.Append(_drawable.GetDrawString());
        }

        private void ChooseDrawable(int i, int j)
        {
            for (int k = 0; k < _players.Count; k++)
            {
                Player player = _players[k];
                _currentPlayer = player;
                if (UnitIsPlayer(i, j))
                {
                    _drawable = new PlayerDrawable(i, j, k, _currentPlayer.wallCounter);
                    return;
                }
            }

            if (UnitIsWall(i, j))
                _drawable = new WallDrawable();
            else if (TileIndexesAreDividableByTwo(i, j))
                _drawable = new SolidTileDrawable(i, j);
            else
                _drawable = new VoidTileDrawable(i, j);
        }

        private bool UnitIsWall(int i, int j)
        {
            Vector2 currentPosition = new Vector2(i, j);
            foreach (Player player in _players)
                foreach (Wall wall in _board.placedWalls)
                    if (CurrentPositionIsWall(currentPosition, wall) && !_board.grid[i, j].isEmpty) 
                        return true;

            return false;
        }

        private bool TileIndexesAreDividableByTwo(int i, int j)
        {
            return i % 2 == 0 && j % 2 == 0;
        }

        private bool UnitIsPlayer(int i, int j)
        {
            return _currentPlayer.position.X == i && _currentPlayer.position.Y == j;
        }

        private static bool CurrentPositionIsWall(Vector2 currentPosition, Wall wall)
        {
            return wall.startPosition == currentPosition || 
                    wall.middlePosition == currentPosition || 
                    wall.endPosition == currentPosition;
        }
    }
}