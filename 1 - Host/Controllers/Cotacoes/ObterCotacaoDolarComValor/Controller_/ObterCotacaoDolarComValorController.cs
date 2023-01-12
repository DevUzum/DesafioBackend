using DesafioBackend.Services.Cotacoes.ObterCotacaoDolarComValor;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackend.Controllers.Cotacoes.ObterCotacaoDolarComValor
{
    [ApiController]
    [RouteTemplate("cliente")]
    public class ObterCotacaoDolarComValorController : ControllerBase
    {
        private const string ProblemaParaRecuperarInformacoes = "Problema para recuperar informações";
        private const string HouveUmProblemaAoConsultarAsInformacoes = "Houve um problema ao consultar as informações, por gentileza tente mais tarde.";

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
            var response = await _obterCotacaoDolarComValorService.ObterCotacaoDolarComValor(
                id, obterCotacaoDolarRequestDto);

            if (response.Cliente == null)
                return NotFound(new ProblemDetails
                {
                    Title = ProblemaParaRecuperarInformacoes,
                    Detail = HouveUmProblemaAoConsultarAsInformacoes
                });

            return response;
        }
    }
}