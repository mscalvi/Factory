namespace DeckManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DeckManager.Views.MainPage());
        }
    }
}
