namespace UserProject.Repositories
{
    using UserProject.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<User> ValidateUserAsync(string userName, string userPassword);
    }
}
