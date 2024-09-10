using FluentValidation;

namespace MyCv.Application.CQRS.ClientCQ.ClientDelete
{
    public sealed class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
    {
        public DeleteClientCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id Alanı Boş Geçilmez") // Id alanı boş olamaz.
                .Must(BeAValidGuid).WithMessage("Geçerli bir GUID değil.")  // Id alanı geçerli bir GUID formatında olmalıdır.
                .NotEqual(Guid.Empty).WithMessage("Id alanı boş GUID olamaz."); // Id alanı Guid.Empty (00000000-0000-0000-0000-000000000000) olamaz.
        }

        private bool BeAValidGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out _);
        }
    }
}
