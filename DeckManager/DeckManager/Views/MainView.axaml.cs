using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace DeckManager.Views;

public partial class MainView : UserControl
{
    private MainWindow _mainWindow;

    public MainView()
    {
        InitializeComponent();
        _mainWindow = this.GetVisualParent<MainWindow>();
    }

    public void BtnCardFinder_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.NavigateToCardFinderView();
    }
}
