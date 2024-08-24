namespace DeckManager.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
    }

    private async void BtnDecks_Clicked(object sender, EventArgs e)
    {

    }

    private async void BtnCards_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new CardFindPage());
    }
}