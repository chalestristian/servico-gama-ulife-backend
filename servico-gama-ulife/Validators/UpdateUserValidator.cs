using FluentValidation;
using servico_gama_ulife.Service.Request;

namespace servico_gama_ulife.Validators
{
    public class UpdateUserValidator : AbstractValidator<EditUser>
    {
        public UpdateUserValidator() 
        {
            RuleFor(p => p.Ds_email)
               .NotNull().WithMessage("E-mail obrigatório!")
               .EmailAddress().WithMessage("Este e-mail não é válido!");

            RuleFor(p => p.Nm_user)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5).WithMessage("Deve ter no mínimo de 5 caracteres!")
                .WithMessage("Nome é obrigatório!");
        }
    }
}
