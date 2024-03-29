﻿using Domain_Layer.Models.UserModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer.DatabaseHelper
{
    public class DatabaseSeedHelper
    {
        private readonly IPasswordHasher<UserModel> _passwordHasher;

        public DatabaseSeedHelper(IPasswordHasher<UserModel> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public void SeedData(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = "08260479-52a0-4c0e-a588-274101a2c3be", FirstName = "Bojan", LastName = "Mirkovic", UserName = "bojan@infinet.com", Email = "bojan@infinet.com", PasswordHash = _passwordHasher.HashPassword(new UserModel(), "Bojan123!"), Role = "Admin" },
                new UserModel { Id = "047425eb-15a5-4310-9d25-e281ab036868", FirstName = "Elliot", LastName = "Dahlin", UserName = "elliot@infinet.com", Email = "elliot@infinet.com", PasswordHash = _passwordHasher.HashPassword(new UserModel(), "Elliot123!"), Role = "Student" },
                new UserModel { Id = "047425eb-15a5-4310-9d25-e281ab036869", FirstName = "Kevin", LastName = "Jorgensen", UserName = "kevin@infinet", Email = "kevin@infinet.com", PasswordHash = _passwordHasher.HashPassword(new UserModel(), "Kevin123!"), Role = "Teacher" }
            );
        }

    }
}
