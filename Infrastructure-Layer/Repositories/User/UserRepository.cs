﻿using Domain_Layer.Models.UserModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserModel> _userManager;
        public UserRepository(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserModel> RegisterUserAsync(UserModel newUser)
        {
            var result = await _userManager.CreateAsync(newUser, newUser.PasswordHash!);
            return newUser;

        }
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user!);
        }
        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user!;
        }
    }
}