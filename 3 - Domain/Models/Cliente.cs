using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBackend.Models
{
    public class Cliente
    {
        public Cliente(Guid id, string nome, string email, decimal multiplicadorBase)
        {
            Id = id;
            Nome = nome;
            Email = email;
            MultiplicadorBase = multiplicadorBase;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal MultiplicadorBase { get; private set; }

        public static Cliente Criar(Guid id, string nome, string email, decimal multiplicadorBase)
        {
            var cliente = new Cliente(id, nome, email, multiplicadorBase);

            return cliente;
        }
    }
}
