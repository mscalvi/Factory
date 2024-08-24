using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DeckManager.Models; 

namespace DeckManager.Services
{
    public class ScryfallService
    {
        private readonly HttpClient _httpClient;

        public ScryfallService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://api.scryfall.com/") };
        }

        public async Task<List<CardModel>> GetCardByName(string cardName)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"cards/named?fuzzy={cardName}");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();

            var cardData = JsonConvert.DeserializeObject<CardData>(responseContent);
            return cardData?.Data ?? new List<CardModel>();
        }

        public async Task<CardModel> GetCardById(string scryfallId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"cards/{scryfallId}");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CardModel>(responseContent);
        }
    }

    public class CardData
    {
        public string Object { get; set; }
        public List<CardModel> Data { get; set; }
        public bool HasMore { get; set; }
    }
}
