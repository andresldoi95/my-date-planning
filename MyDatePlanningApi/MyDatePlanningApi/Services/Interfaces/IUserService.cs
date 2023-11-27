using MyDatePlanningApi.Models.Users;
using MyDatePlanningData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatePlanningApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreatedUser> AddUserAsync(CreateUser user);
        Task<User> GetUserAsync(int id);
        Task<User> GetUserAsync(string email);
        Task UpdateUserAsync(UpdateUser user);
        Task DeleteUserAsync(int id);
    }
}
