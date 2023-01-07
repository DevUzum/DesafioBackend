namespace DesafioBackend.Client.AwesomeApi
{
    public interface ICotacaoMoedaClient
    {
        Task<Cotacao> ObterCotacaoDolar();
    }
}
