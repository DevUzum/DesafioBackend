using DesafioBackend.Controllers.Clientes.Cadastro;
using DesafioBackend.Interfaces;
using DesafioBackend.Models;

namespace DesafioBackend.Services.Clientes.Cadastro
{
    public class CadastroClienteService : ICadastroClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public CadastroClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Guid> CadastrarCliente(
            CadastroClienteRequestDto clienteDto, CancellationToken cancellationToken)
        {
            var clientesComMesmoEmail = _clienteRepository.ObterClientePorEmail(clienteDto.Email);

            if (clientesComMesmoEmail != null)
            {
                return clientesComMesmoEmail.Id;
            }
            else
            {
                var cliente = await Cliente.Criar(
                    Guid.NewGuid(), 
                    clienteDto.Nome, 
                    clienteDto.Email, 
                    clienteDto.MultiplicadorBase);

                _clienteRepository.AddAsync(cliente, cancellationToken);

                return cliente.Id;
            }
        }
    }
}
