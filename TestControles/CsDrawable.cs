using System;

namespace TestControles
{
    internal class CsDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.DrawArc(dirtyRect, 0, 180, true, false);
        }
    }
}
