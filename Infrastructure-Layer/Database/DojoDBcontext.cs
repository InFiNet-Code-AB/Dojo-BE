using System.Reflection.Emit;
using Domain_Layer.Models.UserModel;
using Infrastructure_Layer.DatabaseHelper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer.Database
{
    public class DojoDBContext : IdentityDbContext
    {
        public DojoDBContext()
        {

        }

        public DojoDBContext(DbContextOptions<DojoDBContext> options)
        : base(options)
        {

        }

        public DbSet<UserModel> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            DatabaseSeedHelper.SeedData(builder);
            base.OnModelCreating(builder);
        }

    }
}
