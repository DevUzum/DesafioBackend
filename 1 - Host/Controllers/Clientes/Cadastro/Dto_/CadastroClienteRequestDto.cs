namespace DesafioBackend.Controllers.Clientes.Cadastro
{
    public class CadastroClienteRequestDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public decimal MultiplicadorBase { get; set; }
    }
}
