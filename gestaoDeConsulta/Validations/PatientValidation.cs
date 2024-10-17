using FluentValidation;
using gestaoDeConsulta.Models;

namespace gestaoDeConsulta.Validations
{
    public class PatientValidation : AbstractValidator<Patient>
    {
        public PatientValidation()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Entidade obrigatória")

                .NotNull()
                .WithMessage("Entidade obrigatória");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Campo obrigatório")
                .NotNull()
                .WithMessage("Campo obrigatório")
                .MinimumLength(3)
                .WithMessage("Permitido no mínimo 3 caracteres")
                .MaximumLength(80)
                .WithMessage("Permitido no máximo 80 caracteres");


            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Campo obrigatório")

                .NotNull()
                .WithMessage("Campo obrigatório")

                .MinimumLength(3)
                .WithMessage("Permitido no mínimo 3 caracteres")

                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Formato de e-mail inválido");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Campo obrigatório")

                .NotNull()
                .WithMessage("Campo obrigatório")

                .Matches(@"^(\+55\s?)?(\(?\d{2}\)?\s?)?(\d{4,5}[- ]?\d{4})$")
                .WithMessage("O número de telefone deve seguir o padrão brasileiro, como +55 (XX) XXXX-XXXX ou +55 (XX) XXXXX-XXXX.");



            RuleFor(x => x.CPF)
                .NotEmpty()
                .WithMessage("Campo obrigatório")

                .NotNull()
                .WithMessage("Campo obrigatório")

                .Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$|^\d{11}$")
                .WithMessage("O CPF deve estar no formato 123.456.789-09 ou 12345678909.");


            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage("Campo obrigatório")

                .NotNull()
                .WithMessage("Campo obrigatório");



            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Campo obrigatório")

                .NotNull()
                .WithMessage("Campo obrigatório");

        }
    }
}
