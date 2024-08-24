using System.Net.Http;
using System.Threading.Tasks;

public class ScryfallService
{
    private readonly HttpClient _httpClient;

    public ScryfallService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.scryfall.com/");
    }

    public async Task<string> GetCardbByName(string cardName)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"cards/named?fuzzy={cardName}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetCardById(string scryfallId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"cards/{scryfallId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}