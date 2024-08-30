using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace DeckManager.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void BtnDeckManager_Click (object sender, RoutedEventArgs e)
    {
        BtnDeckManager.IsEnabled = false;
    }

    private void BtnCardFinder_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = this.FindAncestorOfType<MainWindow>();
        if (mainWindow != null)
        {
            mainWindow.NavigateTo(new CardFinderView());
        }
    }
}
