using DesafioBackend.Controllers.Cotacoes.ObterCotacaoDolarComValor;
using FluentValidation;

namespace DesafioBackend.Services.Cotacoes.ObterCotacaoDolarComValor
{
    public class ObterCotacaoDolarComValorValidator : AbstractValidator<ObterCotacaoDolarComValorRequestDto>
    {
        public ObterCotacaoDolarComValorValidator()
        {
            RuleFor(x => x.ValorCotadoEmReais)
                .NotEmpty().WithMessage("O campo ValorCotadoEmReais é de preenchimento obrigatório.");
        }
    }
}
