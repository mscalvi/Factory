using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DeckManager.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Por exemplo, inicializar com a HomeView
        this.FindControl<ContentControl>("MainContent").Content = new MainView();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void NavigateToCardFinderView()
    { 
       this.FindControl<ContentControl>("MainContent").Content = new CardFinderView();
    }
}
