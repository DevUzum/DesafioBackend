using DesafioBackend.Services.Clientes.Cadastro;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackend.Controllers.Clientes.Cadastro
{
    [ApiController]
    [RouteTemplate("clientes")]
    public class CadastroClienteController : ControllerBase
    {
        private readonly ICadastroClienteService _cadastroClienteService;

        public CadastroClienteController(ICadastroClienteService cadastroClienteService)
        {
            _cadastroClienteService = cadastroClienteService;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteResponseDto>> Post(ClienteRequestDto clienteDto, CancellationToken cancellationToken)
        {
            var response = await _cadastroClienteService.CadastrarCliente(clienteDto, cancellationToken);

            return new ClienteResponseDto() { Id = response };
        }
    }
}
