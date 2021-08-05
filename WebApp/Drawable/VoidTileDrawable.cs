namespace QuoridorWebMVC.WebApp.Drawable
{
    public class VoidTileDrawable : IDrawable
    {
        public string GetDrawString()
        {
            return "<td class='cell void'></td>";
        }
    }
}