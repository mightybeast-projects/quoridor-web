using System.Text;
using Quoridor.Core;
using QuoridorWebMVC.WebApp.Drawable;

namespace QuoridorWeb.WebApp
{
    public class WebDrawer
    {
        private Board _board;
        private StringBuilder _table;
        private IDrawable _drawable;

        public WebDrawer(Board board)
        {
            _board = board;
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
            if (TileIndexesAreDividableByTwo(i, j))
                _drawable = new SolidTileDrawable();
            else
                _drawable = new VoidTileDrawable();
        }

        private bool TileIndexesAreDividableByTwo(int i, int j)
        {
            return i % 2 == 0 && j % 2 == 0;
        }
    }
}