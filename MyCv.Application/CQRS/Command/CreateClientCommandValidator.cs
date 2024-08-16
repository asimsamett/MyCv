using FluentValidation;

namespace MyCv.Application.CQRS.Command

{
    public sealed class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Boş giremezsin!!")
                .MaximumLength(123).WithMessage("En fazla 120 karakter olmalı.");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Boş giremezsin!!")
                .MaximumLength(123).WithMessage("En fazla 120 karakter olmalı.");
            //RuleFor(x => x.PhoneNumber)
            //    .NotEmpty().WithMessage("Numara Alanı Zorunludur:")
            //    .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
            RuleFor(x => x.Address).NotEmpty()
                .MaximumLength(50)
                .MinimumLength(5).WithMessage("max karakter 50 min karakter 5");
            /*RuleFor(x => x.PhoneNumber).NotEmpty().GreaterThan(0).WithMessage("Telefon numarası 0 olamaz")
                .LessThan(10).WithMessage("telefon numarsı 10 haneden büyük olamaz")*/
                ;

        }
    }
}
