using FluentValidation;
using Task01.Application.Users.DTOs;

namespace Task01.Application.Users.Validators
{
    public class AddressDtoValidator:AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(x => x.GovernorateId).NotNull().NotEmpty()
                                       .WithMessage("Governorate is required")
                                       .GreaterThan(0)
                                       .WithMessage("Not a valid Governorate");

            RuleFor(x => x.CityId).NotNull().NotEmpty()
                                .WithMessage("City is required")
                                .GreaterThan(0)
                                .WithMessage("Not a valid City");

            RuleFor(x => x.Street).NotNull().NotEmpty()
                .WithMessage("Street can not be empty")
                .MaximumLength(200)
                .WithMessage("Street must not exceed 200 characters.");

            RuleFor(x => x.BuildingNumber).NotNull().NotEmpty()
                .WithMessage("Building number is required");

            RuleFor(x => x.FlatNumber).NotNull().NotEmpty()
                .WithMessage("Flat number is required");
        }
    }
}
