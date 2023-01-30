using Baas.Domain.Commands;
using FluentValidation;

namespace Baas.Domain.Validators
{
    public class AberturaCommandValidator : AbstractValidator<AberturaContaCommand>
    {
        public AberturaCommandValidator()
        {
                RuleFor(x => x.Agencia)
                    .Matches(@"^[0-9]{4}$")
                    .WithMessage("A agência deve conter 4 caracteres numéricos.");
            //
            //    RuleFor(x => x.CodigoCompe)
            //        .Matches(@"^[0-9]{3}$")
            //        .WithMessage("O código compe deve conter 3 caracteres numéricos.");
        }
    }
}