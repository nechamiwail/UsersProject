﻿namespace UserProject.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using UserProject.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> ValidateUserAsync(string userName, string userPassword)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.UserPassword == userPassword);
        }
    }
}
