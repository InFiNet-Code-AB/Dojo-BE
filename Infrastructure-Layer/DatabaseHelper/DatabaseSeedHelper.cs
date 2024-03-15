
using Domain_Layer.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer.DatabaseHelper
{
    public class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);            
            // Add more methods for other entities as needed
        }
        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                 new UserModel { Id = "08260479-52a0-4c0e-a588-274101a2c3be", FirstName = "Bojan", LastName = "Mirkovic" , Email = "bojan@infinet.com", PasswordHash = "Bojan123!", Role = "User" },
            new UserModel { Id = "047425eb-15a5-4310-9d25-e281ab036868", FirstName = "Elliot", LastName = "Dahlin", Email = "elliot@infinet.com", PasswordHash = "Elliot123!", Role = "User" },
            new UserModel { Id = "047425eb-15a5-4310-9d25-e281ab036869", FirstName = "Kevin", LastName = "Jorgensen", Email = "kevin@infinet.com", PasswordHash = "Kevin123!", Role = "User" }
            );
        }
    }
}
