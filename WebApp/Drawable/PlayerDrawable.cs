using QuoridorWeb.WebApp.Drawable;

namespace QuoridorWeb.WebApp.Drawable
{
    public class PlayerDrawable : IDrawable
    {
        private string _imgName;

        public PlayerDrawable(int playerIndex)
        {
            switch(playerIndex)
            {
                case 0:
                    _imgName = "Red_pawn";
                break;
                case 1:
                    _imgName = "Blue_pawn";
                break;
                case 2:
                    _imgName = "Yellow_pawn";
                break;
                case 3:
                    _imgName = "Green_pawn";
                break;
            }
        }

        public string GetDrawString()
        {
            return "<td class='cell solid'><img src='/img/" + _imgName +".svg'></td>";
        }
    }
}