using Task01.Domain.Entities.Users;

namespace Task01.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);

        Task<User> CheckExistance(string email, string mobileNumber);
    }
}
