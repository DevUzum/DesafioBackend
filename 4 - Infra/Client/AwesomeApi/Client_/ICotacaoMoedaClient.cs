namespace DesafioBackend.Client.AwesomeApi
{
    public interface ICotacaoMoedaClient
    {
        Task<USDBRL> ObterMoeda();
    }
}
