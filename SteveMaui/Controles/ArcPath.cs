using SteveMaui.Controles.Drawable;

namespace SteveMaui.Controles;

public class ArcPath : GraphicsView
{
	public ArcPath()
    {
        float[] maListePourcentage = [0.125f, 0.3333f, 0.6667f, 0.9167f];
        Drawable = new DwArcPath(maListePourcentage);
	}
}