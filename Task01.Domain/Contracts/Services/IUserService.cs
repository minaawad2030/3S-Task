using Task01.Domain.Entities.Users;

namespace Task01.Domain.Contracts.Services
{
    public interface IUserService
    {
        Task AddUser(User user);
    }
}
