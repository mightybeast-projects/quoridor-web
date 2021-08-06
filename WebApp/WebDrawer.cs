using System.Collections.Generic;
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
            _table.Append("<table>");

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
                    _drawable = new PlayerDrawable(k);
                    return;
                }
            }

            if (TileIndexesAreDividableByTwo(i, j))
                _drawable = new SolidTileDrawable();
            else
                _drawable = new VoidTileDrawable();
        }

        private bool TileIndexesAreDividableByTwo(int i, int j)
        {
            return i % 2 == 0 && j % 2 == 0;
        }

        private bool UnitIsPlayer(int i, int j)
        {
            return _currentPlayer.position.X == i && _currentPlayer.position.Y == j;
        }
    }
}