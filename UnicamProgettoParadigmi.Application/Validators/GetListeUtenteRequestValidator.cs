using FluentValidation;
using UnicamProgettoParadigmi.Application.Models.Requests;

namespace UnicamProgettoParadigmi.Application.Validators
{
    public class GetListeUtenteRequestValidator : AbstractValidator<GetListeUtenteRequest>
    {
        public GetListeUtenteRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Email obbligatoria")
                .NotNull()
                .WithMessage("Email obbligatoria")
                .EmailAddress()
                .WithMessage("Email non valida");
            RuleFor(x => x.PageSize).GreaterThan(0)
                .WithMessage("PageSize deve essere maggiore di 0");
            RuleFor(x => x.PageNumber).GreaterThan(0)
                .WithMessage("PageNumber deve essere maggiore di 0");
        }
    }
}
