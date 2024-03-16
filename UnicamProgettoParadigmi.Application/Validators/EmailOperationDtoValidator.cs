using FluentValidation;
using UnicamProgettoParadigmi.Application.Models.Dtos;

namespace UnicamProgettoParadigmi.Application.Validators
{
    public class EmailOperationDtoValidator : AbstractValidator<EmailOperationDto>
    {
        public EmailOperationDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Email obbligatoria")
                .NotNull()
                .WithMessage("Email obbligatoria")
                .EmailAddress()
                .WithMessage("Email non valida");
            RuleFor(x => x.NomeLista).NotEmpty()
                .WithMessage("Nome lista obbligatorio")
                .NotNull()
                .WithMessage("Nome lista obbligatorio");

        }
    }
}
