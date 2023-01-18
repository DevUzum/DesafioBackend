using DesafioBackend.Controllers.Cotacoes.ObterCotacaoDolarComValor;

namespace DesafioBackend.Services.Cotacoes.ObterCotacaoDolarComValor
{
    public interface IObterCotacaoDolarComValorService
    {
        Task<ObterCotacaoDolarComValorResponseDto> ObterCotacaoDolarComValor(
            Guid id, ObterCotacaoDolarComValorRequestDto obterCotacaoDolarComValorRequestDto);
    }
}
