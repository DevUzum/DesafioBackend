using DesafioBackend.Controllers.Clientes.Cadastro;
using FluentValidation;

namespace DesafioBackend.Services.Clientes.Cadastro
{
    public class CadastroClienteValidator : AbstractValidator<CadastroClienteRequestDto>
    {
        public CadastroClienteValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo Nome é de preenchimento obrigatório.")
                .Length(3, 150).WithMessage("O campo Nome deve ter entre 3 e 150 caracteres.")
                .Matches(@"^[A-Za-z\s]*$").WithMessage("O campo Nome apenas pode conter letras.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo Email é de preenchimento obrigatório.")
                .Length(13, 200).WithMessage("O campo Email deve ter entre 13 e 200 caracteres.")
                .EmailAddress().WithMessage("O campo Email está no formato incorreto.");
        }
    }
}
