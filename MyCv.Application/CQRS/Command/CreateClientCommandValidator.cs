﻿using FluentValidation;

namespace MyCv.Application.CQRS.Command

{
    public sealed class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {

        public CreateClientCommandValidator()
        {

            // Client Validation

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Boş giremezsin!!")
                .MaximumLength(120).WithMessage("En fazla 120 karakter olmalı.");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Boş giremezsin!!")
                .MaximumLength(123).WithMessage("En fazla 120 karakter olmalı.");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Numara Alanı Zorunludur:")
                .Length(10).WithMessage("Telefon Numarası 10 Haneli Olmalıdır");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Boş giremezsin!!")
                .MaximumLength(50).WithMessage("max 50 karakter")
                .MinimumLength(5).WithMessage("max karakter 50 min karakter 5");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Boş giremezsin!!")
                .MaximumLength(50).WithMessage("max 50 karakter")
                .EmailAddress().WithMessage("Format uygun değil")
                .MinimumLength(5).WithMessage("max karakter 50 min karakter 5");


            // ClientFeature Validation
            
             RuleFor(x => x.ClientFeature)
                .NotNull().WithMessage("ClientFeature boş olamaz.");

            When(x => x.ClientFeature != null, () =>
            {
                RuleFor(x => x.ClientFeature.Education)
                    .NotEmpty().WithMessage("Eğitim boş geçilemez");

                RuleFor(x => x.ClientFeature.Position)
                    .NotEmpty().WithMessage("Pozisyon boş geçilemez");

                RuleFor(x => x.ClientFeature.Referance)
                    .NotEmpty().WithMessage("Referans boş geçilemez")
                    .MaximumLength(50).WithMessage("Maksimum 50 karakter olmalı.");
            });
        }
    }
}
