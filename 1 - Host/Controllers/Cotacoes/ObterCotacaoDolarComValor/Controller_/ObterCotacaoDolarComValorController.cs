using DesafioBackend.Services.Cotacoes.ObterCotacaoDolarComValor;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackend.Controllers.Cotacoes.ObterCotacaoDolarComValor
{
    [ApiController]
    [RouteTemplate("cliente")]
    public class ObterCotacaoDolarComValorController : ControllerBase
    {
        private readonly IObterCotacaoDolarComValorService _obterCotacaoDolarComValorService;

        public ObterCotacaoDolarComValorController(
            IObterCotacaoDolarComValorService obterCotacaoDolarComValorService)
        {
            _obterCotacaoDolarComValorService = obterCotacaoDolarComValorService;
        }

        [HttpPatch("{id}/cotacao")]
        public async Task<ActionResult<ObterCotacaoDolarComValorResponseDto>> Patch(
            [FromRoute] Guid id,
            [FromBody] ObterCotacaoDolarComValorRequestDto obterCotacaoDolarRequestDto,
            CancellationToken cancellationToken)
        {
            return await _obterCotacaoDolarComValorService.ObterCotacaoDolarComValor(
                id, obterCotacaoDolarRequestDto);
        }
    }
}