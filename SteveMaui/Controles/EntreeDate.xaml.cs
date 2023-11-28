namespace SteveMaui.Controles;

public partial class EntreeDate : ContentView
{
    const string MSG_VALEUR_HORS_PLAGE = "La valeur est trop petite ou trop grande.";
    const string MSG_VALEUR_NULLE = "La valeur ne peut pas être nulle.";
    const string MSG_VALEUR_INVALIDE = "La valeur est invalide.";

    public static readonly BindableProperty ValeurMinimumProperty =
        BindableProperty.Create(nameof(ValeurMinimum),
                                typeof(DateTime),
                                typeof(EntreeDate),
                                DateTime.MinValue);

    public DateTime ValeurMinimum
    {
        get => (DateTime)GetValue(ValeurMinimumProperty);
        set
        {
            pckMaDate.MinimumDate = value;
            SetValue(ValeurMinimumProperty, value);
        }
    }

    public static readonly BindableProperty ValeurMaximumProperty =
        BindableProperty.Create(nameof(ValeurMaximum),
                                typeof(DateTime),
                                typeof(EntreeDate),
                                DateTime.MaxValue);

    public DateTime ValeurMaximum
    {
        get => (DateTime)GetValue(ValeurMaximumProperty);
        set
        {
            pckMaDate.MaximumDate = value;
            SetValue(ValeurMaximumProperty, value);
        }
    }

    public static readonly BindableProperty PermettreValeurNullProperty =
        BindableProperty.Create(nameof(PermettreValeurNull),
                                typeof(bool),
                                typeof(EntreeDate),
                                false,
                                BindingMode.TwoWay,
                                null,
                                PermettreValeurNullPropertyChanged);

    public bool PermettreValeurNull
    {
        get => (bool)GetValue(PermettreValeurNullProperty);
        set => SetValue(PermettreValeurNullProperty, value);
    }

    private static void PermettreValeurNullPropertyChanged(BindableObject pBindable, object pVieilleValeur, object pNouvelleValeur)
    {
        var nouvelleValeur = (bool)pNouvelleValeur;
        var monEntree = (EntreeDate)pBindable;

        monEntree.chkEstValeurNulle.IsChecked = nouvelleValeur;
    }

    public static readonly BindableProperty ValeurProperty =
        BindableProperty.Create(nameof(Valeur),
                                typeof(DateTime?),
                                typeof(EntreeDate),
                                null,
                                BindingMode.TwoWay,
                                IsValidValue,
                                OnValeurChanged,
                                null,
                                null,
                                bindable => {
                                    if ((bool)bindable.GetValue(PermettreValeurNullProperty)) return null;
                                    return (DateTime)bindable.GetValue(ValeurMinimumProperty);
                                });

    public DateTime? Valeur
    {
        get => (DateTime?)GetValue(ValeurProperty);
        set
        {
            try
            {
                SetValue(ValeurProperty, value);
            }
            catch
            {
                // Fait rien là à part laisser afficher l'erreur
                // Bin oui le return false du EstValeurValide throw une exception.
            }
        }
    }

    private static bool IsValidValue(BindableObject pView, object pValue)
    {
        var monControle = (EntreeDate)pView;
        return monControle.ValiderControle(pValue);
    }

    private static void OnValeurChanged(BindableObject pBindable, object pVieilleValeur, object pNouvelleValeur)
    {
        var monControle = (EntreeDate)pBindable;
        if (pNouvelleValeur != null)
        {
            monControle.pckMaDate.Date = (DateTime)pNouvelleValeur;
        }
    }

    public static readonly BindableProperty EstValeurValideProperty =
        BindableProperty.Create(nameof(EstValeurValide),
                                typeof(bool),
                                typeof(EntreeDate),
                                false,
                                BindingMode.TwoWay);

    public bool EstValeurValide
    {
        get => (bool)GetValue(EstValeurValideProperty);
        set
        {
            ChangerEtatValidite(value);
            SetValue(EstValeurValideProperty, value);
        }
    }

    public EntreeDate()
	{
		InitializeComponent();
        ChangerEtatValidite(true);
    }

    void ChangerEtatValidite(bool estValide)
    {
        string etatVisuel = estValide ? "Valide" : "Invalide";
        VisualStateManager.GoToState(layoutParent, etatVisuel);
    }

    private bool ValiderControle(object pValue)
    {
        lblTexteAide.Text = string.Empty;

        if (pValue == null)
        {
            if (!PermettreValeurNull)
            {
                lblTexteAide.Text = MSG_VALEUR_NULLE;
                EstValeurValide = false;
                return false;
            }
        }
        else
        {
            if (!DateTime.TryParse(pValue.ToString(), out DateTime resultat))
            {
                lblTexteAide.Text = MSG_VALEUR_INVALIDE;
                EstValeurValide = false;
                return false;
            }

            if (resultat < ValeurMinimum || resultat > ValeurMaximum)
            {
                lblTexteAide.Text = MSG_VALEUR_HORS_PLAGE;
                EstValeurValide = false;
                return false;
            }
        }

        EstValeurValide = true;
        return true;
    }

    private void chkEstValeurNulle_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        PermettreValeurNull = e.Value;
        pckMaDate.IsEnabled = !e.Value;
        if (e.Value)
        {
            Valeur = null;
        }
        else
        {
            var bckMadate = pckMaDate.Date;
            Valeur = ValeurMinimum;
            Valeur = bckMadate.Date;
        }
    }

    private void pckMaDate_DateSelected(object sender, DateChangedEventArgs e)
    {
        Valeur = e.NewDate;
    }

    private void EntreeDate_Loaded(object sender, EventArgs e)
    {
        if(string.Compare(lblTexteAide.Text, MSG_VALEUR_HORS_PLAGE) == 0)
        {
            lblTexteAide.Text = "La valeur initiale donnée au champ est invalide; la valeur a été changée.";
        }
    }
}