using System;

namespace SteveMaui.Controles.Drawable
{
    internal class DwArcPath : IDrawable
    {
        private float[] _listePourcentage;
        private const int GROSSEUR_STROKE = 10;
        private Color[] _listeCouleurAPrendre = {
            new Color(255, 0, 0),
            new Color(0, 0, 255),
            new Color(0, 255, 0),
            new Color(255, 255, 0),
            new Color(192, 192, 192)
        };

        public DwArcPath(float[] listePourcentage)
        {
            _listePourcentage = listePourcentage;

            foreach (var monAngle in _listePourcentage)
            {
                if (monAngle < 0 || monAngle > 1)
                {
                    throw new ArgumentException("La liste des pourcentages doit contenir des valeurs comprises entre 0 et 1.");
                }
            }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            int maCouleurAPrendre = 0;
            for (int i = 0; i < _listePourcentage.Count(); i++)
            {
                var endAngle = _listePourcentage[i] * 360;
                canvas.StrokeSize = GROSSEUR_STROKE;
                canvas.StrokeColor = _listeCouleurAPrendre[maCouleurAPrendre++];
                if (maCouleurAPrendre > _listeCouleurAPrendre.Count() - 1) maCouleurAPrendre = 0;

                int j = i + 1;
                var monRect1 = new RectF(dirtyRect.X + GROSSEUR_STROKE * j,
                                         dirtyRect.Y + GROSSEUR_STROKE * j,
                                         dirtyRect.Width - (GROSSEUR_STROKE * j * 2),
                                         dirtyRect.Height - (GROSSEUR_STROKE * j * 2));
                canvas.DrawArc(monRect1, 0, endAngle, false, false);
            }
        }
    }
}
