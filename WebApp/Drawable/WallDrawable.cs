namespace QuoridorWeb.WebApp.Drawable
{
    public class WallDrawable : IDrawable
    {
        public string GetDrawString()
        {
            return "<td class='cell-void wall'></td>";
        }
    }
}