using FluentValidation;
using FluentValidation.AspNetCore;
using UnicamProgettoParadigmi.Application.Models.Dtos;

namespace UnicamProgettoParadigmi.Application.Validators
{
    public class ListaDistribuzioneDtoValidator : AbstractValidator<ListaDistribuzioneDto>
    {
        public ListaDistribuzioneDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty()
                .WithMessage("Nome obbligatorio")
                .NotNull()
                .WithMessage("Nome obbligatorio")
                .MinimumLength(3)
                .WithMessage("Lunghezza minima nome 3");
            RuleForEach(x => x.Emails).EmailAddress()
                .WithMessage("Email non valida");

        }
    }
}
