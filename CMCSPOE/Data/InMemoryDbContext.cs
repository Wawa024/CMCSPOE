using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CMCSPOE.Models
{
    public class InMemoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Claims.db");
        }

        public DbSet<ClaimModel> Claims { get; set; } 

        public DbSet<User> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "user1@example.com", Password = "password1", Role = "Lecturer" },
                new User { Id = 2, Email = "user2@example.com", Password = "password2", Role = "Lecturer" },
                new User { Id = 3, Email = "user3@example.com", Password = "password2", Role = "Coordinator" }
                );

        }
    }
}

