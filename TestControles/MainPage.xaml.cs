using TestControles.MVVM;

namespace TestControles
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            lblValeur.BindingContext = datDateDebut;
            lblValeur.SetBinding(Label.TextProperty, "Valeur");
            BindingContext = new MonContexte();
        }
    }
}
