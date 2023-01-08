using DesafioBackend.Client.AwesomeApi;
using DesafioBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackend.Controllers.Cotacoes.ObterCotacaoDolarComValor
{
    [ApiController]
    [RouteTemplate("cliente")]
    public class ObterCotacaoDolarComValorController : ControllerBase
    {
        private readonly ICotacaoMoedaClient _cotacaoMoedaClient;
        private readonly IClienteRepository _clienteRepository;

        public ObterCotacaoDolarComValorController(ICotacaoMoedaClient cotacaoMoedaClient, IClienteRepository clienteRepository)
        {
            _cotacaoMoedaClient = cotacaoMoedaClient;
            _clienteRepository = clienteRepository;
        }

        [HttpPatch("{id}/cotacao")]
        public async Task<ActionResult<ObterCotacaoDolarComValorResponseDto>> Patch(
            [FromRoute] Guid id,
            [FromBody] ObterCotacaoDolarRequestDto obterCotacaoDolarRequestDto,
            CancellationToken cancellationToken)
        {
            var cotacao = await _cotacaoMoedaClient.ObterCotacaoDolar();

            var cliente = _clienteRepository.ObterClientePorId(id);

            var cotacaoDolar = Convert.ToDecimal(cotacao.Usdbrl.Bid, System.Globalization.CultureInfo.InvariantCulture);

            var valorCotadoEmReais = obterCotacaoDolarRequestDto.ValorCotadoEmReais;

            if (cliente != null)
                return new ObterCotacaoDolarComValorResponseDto()
                {
                    Cliente = new ClienteDto()
                    {
                        Nome = cliente.Nome,
                        Email = cliente.Email,
                        Id = id
                    },
                    ValorCotadoEmReais = valorCotadoEmReais,
                    ValorOriginal = GetValorOriginal(valorCotadoEmReais, cotacaoDolar),
                    ValorComTaxa = GetValorComTaxa(valorCotadoEmReais, cotacaoDolar, cliente.MultiplicadorBase)
                };

            return NotFound();
        }

        private static decimal GetValorOriginal(decimal valorCotadoEmReais, decimal cotacaoDolar)
        {
            return valorCotadoEmReais / cotacaoDolar;
        }

        private static decimal GetValorComTaxa(decimal valorCotadoEmReais, decimal cotacaoDolar, decimal multiplicadorBase)
        {
            return (valorCotadoEmReais / cotacaoDolar) * multiplicadorBase;
        }
    }
}