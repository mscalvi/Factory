using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DeckManager.Services;
using DeckManager.Models;

namespace DeckManager.Views;

public partial class CardFindPage : ContentPage
{
    public ObservableCollection<CardModel> SearchResults { get; set; } = new ObservableCollection<CardModel>();
    private readonly ScryfallService _scryfallService;

    public CardFindPage()
	{
		InitializeComponent();
        BindingContext = this;
        _scryfallService = new ScryfallService();
    }

    private async void TxtCardSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchResults.Clear();

        if (string.IsNullOrWhiteSpace(e.NewTextValue))
            return;

        await SearchCardsAsync(e.NewTextValue);
    }

    private async Task SearchCardsAsync(string query)
    {
        var results = await _scryfallService.GetCardByName(query);
        foreach (var card in results)
        {
            SearchResults.Add(card);
        }
    }
}