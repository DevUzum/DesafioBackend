using Newtonsoft.Json;

namespace DesafioBackend.Client.AwesomeApi
{
    public class CotacaoMoedaClient : ICotacaoMoedaClient
    {
        public CotacaoMoedaClient()
        {

        }

        public async Task<USDBRL> ObterMoeda()
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://economia.awesomeapi.com.br/last/USD-BRL");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    var jsonObject = JsonConvert.DeserializeObject<USDBRL>(jsonString);
                    
                    return jsonObject;
                }

                return new USDBRL();

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
