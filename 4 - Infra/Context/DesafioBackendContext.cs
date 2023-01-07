using DesafioBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackend.Context
{
    public class DesafioBackendContext : DbContext
    {
        public DesafioBackendContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
