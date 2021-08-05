namespace QuoridorWebMVC.WebApp.Drawable
{
    public class SolidTileDrawable : IDrawable
    {
        public string GetDrawString()
        {
            return "<td class='cell solid'></td>";
        }
    }
}