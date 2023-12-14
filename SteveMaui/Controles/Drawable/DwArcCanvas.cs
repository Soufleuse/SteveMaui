using System;

namespace SteveMaui.Controles.Drawable
{
    internal class DwArcCanvas : IDrawable
    {
        private float[] _listePourcentage;
        private const int GROSSEUR_STROKE = 10;

        public DwArcCanvas(float[] listePourcentage)
        {
            _listePourcentage = listePourcentage.Order().ToArray();
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            for(int i = 0 ; i < _listePourcentage.Length ; i++)
            {
                if (_listePourcentage[i] < 0f || _listePourcentage[i] > 1f)
                {
                    throw new ArgumentOutOfRangeException("_listePourcentage",
                        "Les poucentages doivent être des floats compris entre 0 et 1.");
                }
            }

            float moitieWidth = dirtyRect.Width / 2;
            float moitieHeight = dirtyRect.Height / 2;
            float[] listeRayon = new float[_listePourcentage.Length + 1];

            for (int i = _listePourcentage.Length; i >= 0; i--)
            {
                float rayonAvecWidth = moitieWidth - (i * GROSSEUR_STROKE) - 1;
                float rayonAvecHeight = moitieHeight - (i * GROSSEUR_STROKE) - 1;
                float rayonAPrendre = dirtyRect.Width < dirtyRect.Height ? rayonAvecWidth : rayonAvecHeight;

                listeRayon[i] = rayonAPrendre;

                canvas.DrawCircle(moitieWidth, moitieHeight, rayonAPrendre);

                if (i < _listePourcentage.Length)
                {
                    double monRadian = 2 * Math.PI * _listePourcentage[i];

                    double resultatCos = Math.Cos(monRadian);
                    double resultatSin = Math.Sin(monRadian) * -1;
                    
                    double premierx = resultatCos * rayonAPrendre;
                    double premiery = resultatSin * rayonAPrendre;
                    double deuxiemex = resultatCos * listeRayon[i + 1];
                    double deuxiemey = resultatSin * listeRayon[i + 1];
                    PointF point1 = new PointF((float)(premierx + moitieWidth), (float)(premiery + moitieHeight));
                    PointF point2 = new PointF((float)(deuxiemex + moitieWidth), (float)(deuxiemey + moitieHeight));
                    canvas.DrawLine(point1, point2);
                }
            }

            float debutLigneX = moitieWidth + listeRayon[listeRayon.Length - 1];
            float finLigneX = moitieWidth + listeRayon[0];

            canvas.DrawLine(new PointF(debutLigneX, moitieHeight), new PointF(finLigneX, moitieHeight));
        }
    }
}
