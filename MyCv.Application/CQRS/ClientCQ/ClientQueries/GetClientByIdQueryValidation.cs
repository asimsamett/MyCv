using FluentValidation;

namespace MyCv.Application.CQRS.ClientCQ.ClientQueries
{
    public sealed class GetClientByIdQueryValidation : AbstractValidator<GetClientByIdQuery>
    {
        public GetClientByIdQueryValidation()
        {
            // Id alanı boş olamaz
            RuleFor(query => query.Id)
                .NotEmpty().WithMessage("Id alanı boş geçilemez.") // `Id` alanı boş olamaz.
                .Must(BeAValidGuid).WithMessage("Geçerli bir GUID değil."); // `Id` geçerli bir GUID formatında olmalıdır.
        }

        private bool BeAValidGuid(Guid guid)
        {
            // Guid.Empty, geçersiz bir GUID olarak kabul edilir.
            return guid != Guid.Empty; // `Id` boş değilse geçerli olarak kabul edilir.
        }
    }
}
