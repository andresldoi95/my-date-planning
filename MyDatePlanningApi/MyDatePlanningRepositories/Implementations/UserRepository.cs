using Microsoft.EntityFrameworkCore;
using MyDatePlanningData;
using MyDatePlanningData.Entities;
using MyDatePlanningRepositories.Interfaces;

namespace MyDatePlanningRepositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDatePlanningDBContext _context;
        public UserRepository(MyDatePlanningDBContext context)
        {
            _context = context;
        }
        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsActive = false;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserByUsernameEmailAsync(string usernameEmail)
        {
            return await _context.Users.FirstOrDefaultAsync(u => (u.Email == usernameEmail || u.LoginName == usernameEmail) && u.IsActive);
        }
    }
}
