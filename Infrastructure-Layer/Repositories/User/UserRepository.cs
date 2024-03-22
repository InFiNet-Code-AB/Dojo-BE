﻿using Domain_Layer.Models.UserModel;
using Infrastructure_Layer.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly DojoDBContext _dojoDBContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepository(UserManager<UserModel> userManager, DojoDBContext dojoDBContext, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _dojoDBContext = dojoDBContext;
            _roleManager = roleManager;
        }

        public async Task<UserModel> RegisterUserAsync(UserModel newUser, string password, string role)
        {
            var result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                await _userManager.AddToRoleAsync(newUser, role);

                newUser.Role = role;
                await _userManager.UpdateAsync(newUser);
            }

            return newUser;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user!;
        }

        public async Task<UserModel> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        public Task<UserModel> UpdateUserAsync(UserModel userToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsDeleted = true;
                var result = await _userManager.UpdateAsync(user);
                return result.Succeeded;
            }
            return false;
        }
    }
}
