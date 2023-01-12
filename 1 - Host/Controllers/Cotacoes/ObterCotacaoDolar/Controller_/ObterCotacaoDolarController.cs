using DesafioBackend.Client.AwesomeApi;
using DesafioBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackend.Cotacoes.ObterCotacaoDolar
{
    [ApiController]
    [RouteTemplate("cliente/{id}/cotacao")]
    public class ObterCotacaoDolarController : ControllerBase
    {
        private const string NaoFoiPossivelObterCotacaoDolar = "Não foi possível obter a cotação do dólar";
        private const string HouveUmProblemaAoConsultarServicoDeCotacaoDeMoedas = "Houve um problema ao consultar o serviço de cotação de moedas.";
        private const string IdentificadorDesconhecido = "Identificador desconhecido";
        private const string NaoFoiPossivelEncontrarClienteComIdInformado = "Não foi possível encontrar o cliente com o ID informado.";

        private readonly ICotacaoMoedaClient _cotacaoMoedaClient;
        private readonly IClienteRepository _clienteRepository;

        public ObterCotacaoDolarController(
            ICotacaoMoedaClient cotacaoMoedaClient,
            IClienteRepository clienteRepository)
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

            if (cotacao == null)
                return NotFound(new ProblemDetails
                {
                    Title = NaoFoiPossivelObterCotacaoDolar,
                    Detail = HouveUmProblemaAoConsultarServicoDeCotacaoDeMoedas
                });

            var cliente = _clienteRepository.ObterClientePorId(id);

            if (cliente == null)
                return NotFound(new ProblemDetails
                {
                    Title = IdentificadorDesconhecido,
                    Detail = NaoFoiPossivelEncontrarClienteComIdInformado
                });

            var valorOriginal = Convert.ToDecimal(
                cotacao.Usdbrl.Bid, System.Globalization.CultureInfo.InvariantCulture);

            return new ObterCotacaoDolarResponseDto()
            { ValorOriginal = valorOriginal, ValorComTaxa = valorOriginal * cliente.MultiplicadorBase };
        }
    }
}
