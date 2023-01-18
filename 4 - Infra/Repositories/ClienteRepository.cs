using DesafioBackend.Context;
using DesafioBackend.Interfaces;
using DesafioBackend.Models;

namespace DesafioBackend.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private DesafioBackendContext _desafioBackendContext;

        public ClienteRepository(DesafioBackendContext desafioBackendContext)
        {
            _desafioBackendContext = desafioBackendContext;
        }

        public void AddAsync(Cliente cliente, CancellationToken cancellationToken)
        {
            _desafioBackendContext.Clientes.Add(cliente);
            _desafioBackendContext.SaveChanges();
        }

        public Cliente ObterClientePorId(Guid id)
        {
            return _desafioBackendContext.Clientes?
                .Where(x => x.Id == id)
                .ToList()
                .FirstOrDefault();
        }

        public Cliente ObterClientePorEmail(string email)
        {
            return _desafioBackendContext.Clientes?
                .Where(x => x.Email == email)
                .ToList()
                .FirstOrDefault();
        }

    }
}
