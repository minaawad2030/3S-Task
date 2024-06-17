using Task01.Application.Utilities.Exceptions;
using Task01.Domain.Contracts.Services;
using Task01.Domain.Entities.Users;
using Task01.Domain.Interfaces;

namespace Task01.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUser(User user)
        {
            var registeredUser = await _unitOfWork.UserRepository.CheckExistance(user.Email, user.MobileNumber);

            if (registeredUser != null) {
                throw new Task01Exception("Email or Mobile number is already exist");
            }
            await _unitOfWork.UserRepository.AddUserAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
