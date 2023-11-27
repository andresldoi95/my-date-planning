using MyDatePlanningData.Entities;

namespace MyDatePlanningRepositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User> GetUserAsync(int id);
        Task<User> GetUserAsync(string email);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    
    }
}
