using AutoMapper;
using FluentValidation;
using MediatR;
using Task01.Application.Users.DTOs;
using Task01.Domain.Contracts.Services;
using Task01.Domain.Entities.Users;

namespace Task01.Application.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserService _userService;
        private readonly IValidator<CreateUserCommand> _createUserCommandValidator;
        private readonly IValidator<AddressDto> _addressDtoValidator;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserService userService, IMapper mapper, IValidator<CreateUserCommand> validator, IValidator<AddressDto> addressDtoValidator)
        {
            _mapper = mapper;
            _userService = userService;
            _createUserCommandValidator = validator;
            _addressDtoValidator = addressDtoValidator;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request, cancellationToken);
            var user = _mapper.Map<User>(request);
            user.Addresses = request.Addresses.Select(_mapper.Map<Address>).ToList();
            await _userService.AddUser(user);
            return user;
        }

        private async Task ValidateRequest(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createUserValidationResult = await _createUserCommandValidator.ValidateAsync(request, cancellationToken);
            if (!createUserValidationResult.IsValid)
                throw new ValidationException(createUserValidationResult.Errors.Select(x => x.ErrorMessage).FirstOrDefault());

            foreach (var address in request.Addresses)
            {
                var addressDtoValidationResult = await _addressDtoValidator.ValidateAsync(address, cancellationToken);
                if (!addressDtoValidationResult.IsValid)
                    throw new ValidationException(addressDtoValidationResult.Errors.Select(x => x.ErrorMessage).FirstOrDefault());
            }
        }
    }
}
