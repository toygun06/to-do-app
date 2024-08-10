using Application.Features.Auth.Command.Register;
using FluentValidation;

namespace Application.Features.Auth.Validations
{
    public class PatientRegisterValidator : AbstractValidator<UserRegisterCommand>
    {
        public PatientRegisterValidator()
        {
            RuleFor(user => user.FirstName)
           .NotEmpty()
           .MaximumLength(50);

            RuleFor(user => user.LastName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Telefon numarası geçerli bir telefon numarası olmalıdır.");

            RuleFor(user => user.Password)
                .NotEmpty()
                .MinimumLength(6)
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir.");
        }
    }
}
