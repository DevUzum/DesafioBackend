using DesafioBackend.Models;

namespace DesafioBackend.Interfaces
{
    public interface IClienteRepository
    {
        void AddAsync(Cliente cliente, CancellationToken cancellationToken);

        Cliente? ObterClientePorId(Guid id);

        Cliente? ObterClientePorEmail(string email);
    }
}
