using Newtonsoft.Json;

namespace DesafioBackend.Client.AwesomeApi
{
    public class CotacaoMoedaClient : ICotacaoMoedaClient
    {
        public async Task<Cotacao> ObterCotacaoDolar()
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://economia.awesomeapi.com.br/last/USD-BRL");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                var jsonObject = JsonConvert.DeserializeObject<Cotacao>(jsonString);

                return jsonObject;
            }

            return new Cotacao();
        }
    }
}
