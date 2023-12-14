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

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            var i = 0;
        }
    }
}
