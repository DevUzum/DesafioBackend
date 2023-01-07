using DesafioBackend.Models;

namespace DesafioBackend.Interfaces
{
    public interface IClienteRepository
    {
        void AddAsync(Cliente cliente, CancellationToken cancellationToken);

        Cliente? GetCliente(string email);
    }
}
