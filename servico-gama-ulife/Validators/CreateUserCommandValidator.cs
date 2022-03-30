using FluentValidation;
using servico_gama_ulife.Service.Request;

namespace servico_gama_ulife.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<AddUser>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Nr_registry)
                .NotNull().WithMessage("Matrícula é obrigatória!")
                .NotEmpty();

            RuleFor(p => p.Ds_email)
                .NotNull().WithMessage("E-mail obrigatório!")
                .EmailAddress().WithMessage("Este e-mail não é válido!");

            RuleFor(p => p.Ds_password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6).WithMessage("Senha deve conter 6 caracteres.");

            RuleFor(p => p.Nm_user)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5).WithMessage("Deve ter no mínimo de 5 caracteres!")
                .WithMessage("Nome é obrigatório!");

            RuleFor(p => p.Ds_usertypeid)
                .Must(p => p == 1 || p == 2)
                .WithMessage("Preencha com 1 para Estudante ou 2 para Professor(a) ");
        }
    }
}
