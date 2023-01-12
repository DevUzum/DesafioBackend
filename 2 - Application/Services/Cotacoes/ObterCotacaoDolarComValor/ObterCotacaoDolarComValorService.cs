using DesafioBackend.Client.AwesomeApi;
using DesafioBackend.Controllers.Cotacoes.ObterCotacaoDolarComValor;
using DesafioBackend.Interfaces;
using DesafioBackend.Models;

namespace DesafioBackend.Services.Cotacoes.ObterCotacaoDolarComValor
{
    public class ObterCotacaoDolarComValorService : IObterCotacaoDolarComValorService
    {
        private readonly ICotacaoMoedaClient _cotacaoMoedaClient;
        private readonly IClienteRepository _clienteRepository;

        public ObterCotacaoDolarComValorService(
            ICotacaoMoedaClient cotacaoMoedaClient, 
            IClienteRepository clienteRepository)
        {
            _cotacaoMoedaClient = cotacaoMoedaClient;
            _clienteRepository = clienteRepository;
        }

        public async Task<ObterCotacaoDolarComValorResponseDto> ObterCotacaoDolarComValor(
            Guid id, ObterCotacaoDolarComValorRequestDto obterCotacaoDolarRequestDto)
        {
            var cliente = _clienteRepository.ObterClientePorId(id);

            if (cliente == null)
                return new ObterCotacaoDolarComValorResponseDto();

            var cotacao = await _cotacaoMoedaClient.ObterCotacaoDolar();

            if (cotacao == null)
                return new ObterCotacaoDolarComValorResponseDto();

            var cotacaoDolar = Convert.ToDecimal(
                cotacao.Usdbrl.Bid,
                System.Globalization.CultureInfo.InvariantCulture);

            return MapResonse(id, cliente, cotacaoDolar, obterCotacaoDolarRequestDto.ValorCotadoEmReais.Value);
        }

        private static ObterCotacaoDolarComValorResponseDto MapResonse(
            Guid id, Cliente cliente, decimal cotacaoDolar, decimal valorCotadoEmReais)
        {
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
        }

        private static decimal GetValorOriginal(
            decimal valorCotadoEmReais, decimal cotacaoDolar) 
                => valorCotadoEmReais / cotacaoDolar;
        

        private static decimal GetValorComTaxa(
            decimal valorCotadoEmReais, decimal cotacaoDolar, decimal multiplicadorBase)
                => (valorCotadoEmReais / cotacaoDolar) * multiplicadorBase;      
    }
}
