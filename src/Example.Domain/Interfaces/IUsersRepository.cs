using System;
using System.Threading.Tasks;
using Example.Domain.Models;
using Example.Domain.Resources.Users;

namespace Example.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> LoginAsync(UserLoginResource credentials);
        Task<User> RegisterAsync(User user, string password);
    }
}
