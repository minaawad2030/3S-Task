using FluentValidation;
using Task01.Application.Users.Commands.Create;

namespace Task01.Application.Users.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly string _nameRegex = "^[ا-يA-Za-z\\s ]+$";
        private readonly string _phoneNumberRegex = "^\\+201[0125][0-9]{8}$";

        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email is required")
                .EmailAddress().WithMessage("A valid email is required");

            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("First name is required")
                .MaximumLength(20).WithMessage("Max length is 20")
            .Matches(_nameRegex).WithMessage("Enter a valid first name");

            RuleFor(x => x.MiddleName).MaximumLength(40).WithMessage("Max length is 40")
                .Matches(_nameRegex).WithMessage("Enter a valid Middle name");

            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("Last name is required")
               .MaximumLength(20).WithMessage("Max length is 20")
           .Matches(_nameRegex).WithMessage("Enter a valid last name");

            RuleFor(x => x.BirthDate).NotEmpty().NotNull().WithMessage("Birthdate is requird")
                .Must(AllowedAge).WithMessage("Minimum age is 20 years old");

            RuleFor(x => x.MobileNumber).NotEmpty().NotNull().WithMessage("Mobile number is required")
                .Matches(_phoneNumberRegex).WithMessage("Enter a valid phone number");
        }

        private bool AllowedAge(DateOnly date)
        {
            var today = DateTime.Now;
            var userBirthDate = date.ToDateTime(TimeOnly.Parse("01:00 PM"));
            return (today - userBirthDate).Days / 365 >= 20;
        }
    }
}
