using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft;

namespace DeckManager.Services
{
    public class ScryfallAPI
    {
        private readonly HttpClient _httpClient;

        public ScryfallAPI()
        {
            _httpClient = new HttpClient();

            // Definir a URL base da Scryfall API
            _httpClient.BaseAddress = new Uri("https://api.scryfall.com/");

            // Adicionando cabeçalhos necessários
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "DeckManager/1.0");  // Nome do seu aplicativo
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); // Garantir que recebemos JSON
        }

        // Método para buscar carta pelo nome
        public async Task<string> SearchCardByNameAsync(string cardName)
        {
            try
            {
                // Codificar o nome da carta para evitar problemas com caracteres especiais na URL
                string encodedCardName = Uri.EscapeDataString(cardName);

                // Montar a URL para a requisição
                string url = $"cards/search?q={encodedCardName}";

                // Fazer a requisição GET para a Scryfall API
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Verificar se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return jsonResponse;
                }
                else
                {
                    return $"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
            catch (HttpRequestException e)
            {
                return $"Erro na requisição: {e.Message}";
            }
        }

    }
}
