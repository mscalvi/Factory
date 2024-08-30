using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DeckManager.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new MainView();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void NavigateTo(UserControl view)
        {
            MainContent.Content = view;
        }
    }
}