using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BloodBorne.Model;
using System.Threading.Tasks;

namespace BloodBorne.Context
{
    public class UserProvider
    {
        private readonly UserManager<User> _userManager;

        public UserProvider(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // Get a user by ID
        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userManager.Users
                .Include(u => u.Comments) // Include related comments
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        // Get a user by Username
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userManager.Users
                .Include(u => u.Comments)
                .FirstOrDefaultAsync(u => u.UserName == username);
        }

        // Create a new user
        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        // Check if a user exists by username
        public async Task<bool> UserExistsAsync(string username)
        {
            return await _userManager.Users.AnyAsync(u => u.UserName == username);
        }

    }

}


