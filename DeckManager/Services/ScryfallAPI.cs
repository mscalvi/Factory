using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager.Services
{
    public class ScryfallAPI
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string baseUrl = "https://api.scryfall.com/cards/";

        // Método para buscar carta por nome (ou outros parâmetros de query)
        public async Task<string> SearchCard(string cardName)
        {
            try
            {
                string url = $"{baseUrl}search?q={cardName}"; // Query de busca por nome
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                // Tratar o erro e retornar mensagem apropriada
                return $"Erro na requisição: {e.Message}";
            }
        }
    }
}
