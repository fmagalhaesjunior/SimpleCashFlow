using Core.Entities;
using FluentValidation;

namespace Application.Validators
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty().WithMessage("Id não deve ser vazio.")
                .Must(BeAValidGuid).WithMessage("O ID deve ser um GUID válido.");
        }

        private bool BeAValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
