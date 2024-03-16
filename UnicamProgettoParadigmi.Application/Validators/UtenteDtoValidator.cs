using FluentValidation;
using UnicamProgettoParadigmi.Application.Extensions;
using UnicamProgettoParadigmi.Application.Models.Dtos;

namespace UnicamProgettoParadigmi.Application.Validators
{
    public class UtenteDtoValidator : AbstractValidator<UtenteDto>
    {
        public UtenteDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Email obbligatoria")
                .NotNull()
                .WithMessage("Email obbligatoria")
                .EmailAddress()
                .WithMessage("Deve essere una mail");
            RuleFor(x => x.Nome).NotEmpty()
                .WithMessage("Nome obbligatorio")
                .NotNull()
                .WithMessage("Nome obbligatorio")
                .MinimumLength(3)
                .WithMessage("Lunghezza minima nome 3");
            RuleFor(x => x.Cognome).NotEmpty()
                .WithMessage("Cognome obbligatorio")
                .NotNull()
                .WithMessage("Cognome obbligatorio")
                .MinimumLength(3)
                .WithMessage("Lunghezza minima cognome 3");
            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Il campo password è obbligatorio")
                .NotNull()
                .WithMessage("Il campo password non può essere nullo")
                .MinimumLength(6)
                .WithMessage("Il campo password deve essere almeno lungo 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale"
                ); ;
        }
    }
}
