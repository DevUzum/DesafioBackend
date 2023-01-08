using DesafioBackend.Client.AwesomeApi;
using DesafioBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackend.Cotacoes.ObterCotacaoDolar
{
    [ApiController]
    [RouteTemplate("cliente/{id}/cotacao")]
    public class ObterCotacaoDolarController : ControllerBase
    {
        private readonly ICotacaoMoedaClient _cotacaoMoedaClient;
        private readonly IClienteRepository _clienteRepository;

        public ObterCotacaoDolarController(ICotacaoMoedaClient cotacaoMoedaClient, IClienteRepository clienteRepository)
        {
            _cotacaoMoedaClient = cotacaoMoedaClient;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ObterCotacaoDolarResponseDto>> Get(
            [FromRoute] Guid id, 
            CancellationToken cancellationToken)
        {
            var cotacao = await _cotacaoMoedaClient.ObterCotacaoDolar();

            var cliente = _clienteRepository.ObterClientePorId(id);

            var valorOriginal = Convert.ToDecimal(cotacao.Usdbrl.Bid, System.Globalization.CultureInfo.InvariantCulture);

            if (cliente != null)
                return new ObterCotacaoDolarResponseDto() 
                    { ValorOriginal = valorOriginal, ValorComTaxa = valorOriginal * cliente.MultiplicadorBase};

            return NotFound();
        }
    }
}
