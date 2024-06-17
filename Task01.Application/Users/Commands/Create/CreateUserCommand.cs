using MediatR;
using Task01.Application.Users.DTOs;
using Task01.Domain.Entities.Users;

namespace Task01.Application.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<User>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    }
}
