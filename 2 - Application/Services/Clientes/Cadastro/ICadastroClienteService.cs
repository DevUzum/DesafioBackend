using DesafioBackend.Controllers.Clientes.Cadastro;
using DesafioBackend.Models;

namespace DesafioBackend.Services.Clientes.Cadastro
{
    public interface ICadastroClienteService
    {
        Task<Guid> CadastrarCliente(ClienteRequestDto clienteDto, CancellationToken cancellationToken);
    }
}
