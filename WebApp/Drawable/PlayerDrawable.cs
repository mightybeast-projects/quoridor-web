using System.Collections.Generic;
using System.Text;

namespace QuoridorWeb.WebApp.Drawable
{
    public class PlayerDrawable : TileDrawable, IDrawable
    {
        private int _playerIndex;
        private string _imgName;
        private int _wallCounter;
        private List<string> _imgNames = new List<string>()
            { "Red_pawn", "Blue_pawn", "Yellow_pawn", "Green_pawn"};

        public PlayerDrawable(int i, int j, int playerIndex, int wallCounter) : base(i, j)
        {
            _playerIndex = playerIndex;
            _imgName = _imgNames[playerIndex];
            _wallCounter = wallCounter;
        }

        public string GetDrawString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<td ");
            str.Append("position='" + _pos + "'");
            str.Append("class='cell-solid player-cell'");
            str.Append(">");
            str.Append(GetPlayerImageTag());
            str.Append(GetWallCounterTag());
            str.Append("</td>");

            return str.ToString();
        }

        private string GetPlayerImageTag()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<img ");
            str.Append("id='player-" + _playerIndex + "'");
            str.Append("class='player'");
            str.Append("src='/img/" + _imgName + ".svg'");
            str.Append(GetOnClickFunctionsStr());
            str.Append(">");

            return str.ToString();
        }

        private string GetOnClickFunctionsStr()
        {
            StringBuilder str = new StringBuilder();
            str.Append("onclick='");
            str.Append("if(checkCurrentPlayerIndex(" + _playerIndex + "))");
            str.Append("{");
            str.Append("selectPlayer($(this).parent().attr(`position`));");
            str.Append("blink(this)");
            str.Append("}'");

            return str.ToString();
        }

        private string GetWallCounterTag() 
        {
            StringBuilder str = new StringBuilder();
            str.Append("<div class='wall-counter-div'>");
            str.Append("<img class='wall-counter-img' src='/img/walls.png' />");
            str.Append("<p class='wall-counter-label'>x" + _wallCounter + "</p>");
            str.Append("</div>");

            return str.ToString();
        }
    }
}