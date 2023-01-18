using DesafioBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackend.Builders
{
    public class ClienteBuilder
    {
        public void Build(EntityTypeBuilder<Cliente> clienteBuilder)
        {
            clienteBuilder.HasKey(x => x.Id)
                .IsClustered(false);

            clienteBuilder.Property(x => x.Nome)
                .HasMaxLength(150)
                .IsRequired();

            clienteBuilder.Property(x => x.Email)
                .HasMaxLength(200)
                .IsRequired();

            clienteBuilder.Property(x => x.MultiplicadorBase);
        }
    }
}
