using SteveMaui.Controles.Drawable;

namespace SteveMaui.Controles;

public class ArcCanvas : GraphicsView
{
	public ArcCanvas()
	{
        Loaded += ArcCanvas_Loaded;
        float[] maListePourcentage = [0.125f, 0.3333f, 0.6667f, 0.9167f];
		Drawable = new DwArcCanvas(maListePourcentage);
	}

    private void ArcCanvas_Loaded(object? sender, EventArgs e)
    {
        var i = 0;
    }
}