using System;
namespace QuoridorWeb.WebApp.Drawable
{
    public class VoidTileDrawable : TileDrawable, IDrawable
    {
        public VoidTileDrawable(int i, int j) : base(i, j) { }

        public string GetDrawString()
        {
            return "<td position='" + _pos + "' class='cell-void' onclick='DisplayPosition(this.getAttribute(`position`))'></td>";
        }
    }
}