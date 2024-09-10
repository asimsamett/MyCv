using Elasticsearch.Net.Specification.MigrationApi;
using FluentValidation;

namespace MyCv.Application.CQRS.ClientCQ.ClientCreate
{
    public sealed class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            // İsim alanı için validasyon kuralları
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Boş giremezsin!!") // İsim alanı boş olamaz.
                .MaximumLength(120).WithMessage("En fazla 120 karakter olmalı."); // İsim en fazla 120 karakter uzunluğunda olabilir.

            // Soyisim alanı için validasyon kuralları
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Boş giremezsin!!") // Soyisim alanı boş olamaz.
                .MaximumLength(123).WithMessage("En fazla 120 karakter olmalı."); // Soyisim en fazla 123 karakter uzunluğunda olabilir. (Düzeltme: Hata mesajında 120 karakter sınırı yerine 123 karakter sınır belirtilmiş.)

            // Telefon numarası için validasyon kuralları
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Numara Alanı Zorunludur:") // Telefon numarası boş olamaz.
                .Length(10).WithMessage("Telefon Numarası 10 Haneli Olmalıdır"); // Telefon numarası tam olarak 10 karakter uzunluğunda olmalıdır.

            // Adres alanı için validasyon kuralları
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Boş giremezsin!!") // Adres alanı boş olamaz.
                .MaximumLength(50).WithMessage("max 50 karakter") // Adres en fazla 50 karakter uzunluğunda olabilir.
                .MinimumLength(5).WithMessage("max karakter 50 min karakter 5"); // Adres en az 5 karakter uzunluğunda olmalıdır.

            // E-posta adresi için validasyon kuralları
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Boş giremezsin!!") // E-posta alanı boş olamaz.
                .MaximumLength(50).WithMessage("max 50 karakter") // E-posta en fazla 50 karakter uzunluğunda olabilir.
                .EmailAddress().WithMessage("Format uygun değil") // E-posta geçerli bir formatta olmalıdır.
                .MinimumLength(5).WithMessage("max karakter 50 min karakter 5"); // E-posta en az 5 karakter uzunluğunda olmalıdır.

            // ClientFeature alanı için validasyon kuralları
            RuleFor(x => x.ClientFeature)
                .NotNull().WithMessage("ClientFeature boş olamaz."); // `ClientFeature` alanı boş olamaz.

            // `ClientFeature` alanı boş değilse ek validasyon kuralları
            When(x => x.ClientFeature != null, () =>
            {
                RuleFor(x => x.ClientFeature.Education)
                    .NotEmpty().WithMessage("Eğitim boş geçilemez"); // Eğitim alanı boş olamaz.

                RuleFor(x => x.ClientFeature.Position)
                    .NotEmpty().WithMessage("Pozisyon boş geçilemez"); // Pozisyon alanı boş olamaz.

                RuleFor(x => x.ClientFeature.Referance)
                    .NotEmpty().WithMessage("Referans boş geçilemez") // Referans alanı boş olamaz.
                    .MaximumLength(50).WithMessage("Maksimum 50 karakter olmalı."); // Referans en fazla 50 karakter uzunluğunda olabilir.
            });
            

        }

        
    }
}
