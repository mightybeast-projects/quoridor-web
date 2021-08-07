namespace QuoridorWeb.WebApp.Drawable
{
    public class SolidTileDrawable : TileDrawable, IDrawable
    {
        public SolidTileDrawable(int i, int j) : base(i, j) { }

        public string GetDrawString()
        {
            return "<td position='" + _pos + "' class='cell-solid'></td>";
        }
    }
}