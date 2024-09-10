using FluentValidation;

namespace MyCv.Application.CQRS.ClientCQ.ClientQueries
{
    public sealed class GetClientQueryValidation : AbstractValidator<GetClientQuery>
    {
        public GetClientQueryValidation()
        {
            // Id alanı boş olamaz
            RuleFor(query => query.Id)
                .NotEmpty().WithMessage("Id alanı boş geçilemez.") // `Id` alanı boş olamaz.
                .Must(BeAValidGuid).WithMessage("Geçerli bir GUID değil."); // `Id` geçerli bir GUID formatında olmalıdır.

            // Name alanı en az 2 karakter olmalı
            RuleFor(query => query.Name)
                .MinimumLength(2).WithMessage("İsim alanı en az 2 karakter olmalıdır.") // `Name` alanı en az 2 karakter uzunluğunda olmalıdır.
                .When(query => !string.IsNullOrEmpty(query.Name)); // Eğer `Name` alanı boş değilse bu kural geçerli olur.

            // Surname alanı en az 2 karakter olmalı
            RuleFor(query => query.Surname)
                .MinimumLength(2).WithMessage("Soyisim alanı en az 2 karakter olmalıdır.") // `Surname` alanı en az 2 karakter uzunluğunda olmalıdır.
                .When(query => !string.IsNullOrEmpty(query.Surname)); // Eğer `Surname` alanı boş değilse bu kural geçerli olur.

            // Email alanı geçerli bir e-posta formatında olmalı
            RuleFor(query => query.Email)
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.") // `Email` geçerli bir e-posta formatında olmalıdır.
                .When(query => !string.IsNullOrEmpty(query.Email)); // Eğer `Email` alanı boş değilse bu kural geçerli olur.

            // PhoneNumber alanı boşsa ya da belirli bir formata uygun olmalı (örneğin 10 haneli)
            RuleFor(query => query.PhoneNumber)
                .Matches(@"^\d{10}$").WithMessage("Telefon numarası 10 haneli olmalıdır.") // `PhoneNumber` alanı 10 haneli olmalıdır.
                .When(query => !string.IsNullOrEmpty(query.PhoneNumber)); // Eğer `PhoneNumber` alanı boş değilse bu kural geçerli olur.
        }

        // GUID geçerliliğini kontrol eden özel metod
        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty; // Boş GUID geçersiz kabul edilir.
        }
    }
}
